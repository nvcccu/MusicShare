using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DAO.Enums;
using DAO.Extensions;
using DAO.Filters.Join;
using DAO.Filters.Order;
using DAO.Filters.Set;
using DAO.Filters.Where;
using Npgsql;

namespace DAO {
    public interface IAbstractEntity {
        string TableName { get; set; }
        List<IAbstractEntity> JoinedEntities { get; set; }
    }

    public abstract class AbstractEntity<T> : IAbstractEntity where T: new() {
        private readonly DbAdapter _dbAdapter;
        private FilterWhereCollection _filterWhere;
        private List<FilterSet> _filterSet;
        private List<FilterJoin> _filterJoin;
        private List<FilterOrder> _filterOrder;
        private string _query;

        public string TableName { get; set; }
        public List<IAbstractEntity> JoinedEntities { get; set; }
        
#if DEBUG
        // Для тестов.
        public string Query {
            get { return _query; }
        }
#endif

        protected AbstractEntity(string tableName) {
            _dbAdapter = new DbAdapter();
            _filterWhere = new FilterWhereCollection();
            _filterOrder = new List<FilterOrder>();
            _filterJoin = new List<FilterJoin>();
            _filterSet = new List<FilterSet>();
            JoinedEntities = new List<IAbstractEntity>();
            TableName = tableName;
        }

        public AbstractEntity<T> Update() {
            _query = "UPDATE " + TableName + " ";
            return this;
        }

        private string FixDate(object value) {
            if (value is DateTime) {
                return String.Format("{0:yyyy-MM-dd HH:mm:ss}", value);
            } else {
                return value.ToString();
            }
        }

        /// <summary>
        /// Сохраняет в базу сущность БЕЗ АЙДИШКИ и возвращает присвоенную АЙДИШКУ
        /// </summary>
        public object Insert() {
            object id = null;
            PropertyInfo property;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            _query = "INSERT INTO " + TableName + " (";
            for (var i = 1; i < properties.Count() - 1; i++) {
                property = properties[i];
                _query += property.Name + ", ";
            }
            _query += properties[properties.Count() - 1].Name + ") ";
            _query += "VALUES (";
            string propValue;
            for (var i = 1; i < properties.Count() - 1; i++) {
                property = properties[i];
                propValue = FixDate(property.GetValue(this, null));
                _query += String.IsNullOrEmpty(propValue) ? "NULL, " : ("'" + propValue.Replace("'", "''") + "', ");
            }
            property = properties[properties.Count() - 1];
            propValue = FixDate(property.GetValue(this, null));
            _query += String.IsNullOrEmpty(propValue) ? "NULL" : ("'" + propValue.Replace("'", "''") + "'");
            _query += ") RETURNING " + properties.First().Name + ";";
            Console.WriteLine(_query);
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            _dbAdapter.OpenConnection();
            try {
                id = _dbAdapter.Command.ExecuteScalar();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
            return id;
        }
        /// <summary>
        /// Сохраняет в базу сущность С АЙДИШКОЙ
        /// TODO: Подставлять имя первичного ключа по атрибуту, а не брать первую пропертю
        /// </summary>
        public void Save() {
            PropertyInfo property;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            _query = "INSERT INTO " + TableName + " (";
            for (var i = 0; i < properties.Count() - 1; i++) {
                property = properties[i];
                _query += property.Name + ", ";
            }
            _query += properties[properties.Count() - 1].Name + ") ";
            _query += "VALUES (";
            string propValue;
            for (var i = 0; i < properties.Count() - 1; i++) {
                property = properties[i];
                propValue = FixDate(property.GetValue(this, null));
                _query += String.IsNullOrEmpty(propValue) ? "NULL, " : ("'" + propValue.Replace("'", "''") + "', ");
            }
            property = properties[properties.Count() - 1];
            propValue = FixDate(property.GetValue(this, null));
            _query += String.IsNullOrEmpty(propValue) ? "NULL" : ("'" + propValue.Replace("'", "''") + "'");
            _query += ") RETURNING " + properties.First().Name + ";";
            Console.WriteLine(_query);
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            _dbAdapter.OpenConnection();
            try {
                _dbAdapter.Command.ExecuteScalar();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
        }

        /// <summary>
        /// Запрос на выборку
        /// todo: заменить * на явное перечисление полей
        /// todo: запилить возможность получения только нужных полей
        /// </summary>
        /// <returns></returns>
        public AbstractEntity<T> Select() {
            _query = "SELECT * FROM " + TableName + " ";
            return this;
        }

        /// <summary>
        /// выполняет запрос без возвращения данных
        /// </summary>
        public void ExecuteScalar() {
            TranslateJoin();
            TranslateSet();
            TranslateWhere();
            TranslateOrder();
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            _dbAdapter.OpenConnection();
            try {
                _dbAdapter.Command.ExecuteScalar();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
        }

        /// <summary>
        /// Получение данных из таблицы
        /// todo: запилить возможность получения только нужных полей, указание полей поместить в Select()
        /// todo: продумать, как вытащить логику обращения к базе из этого метода
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetData() {
            TranslateJoin();
            TranslateWhere();
            TranslateOrder();
            TranslateSet();
            var ret = new List<T>();
            _dbAdapter.OpenConnection();
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            try {
                _dbAdapter.DataReader = _dbAdapter.Command.ExecuteReader();
                int k = 0;
                while (_dbAdapter.DataReader.Read()) {
                    var cur = new T();
                    var properties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList();
                    int i;
                    int j;
                    var propertiesCount = properties.Count();
                    var values = new object[propertiesCount];
                    if (_dbAdapter.DataReader.GetValues(values) != propertiesCount) {
                        throw new Exception("Число полей в сущности не равно числу полей, возвращенных из запроса.");
                    }
                    for (i = 0; i < propertiesCount; i++) {
                        var name = _dbAdapter.DataReader.GetName(i);
                        var val = values[i];
                        var propertyIndex = properties.FindIndex(p => String.Equals(p.Name, name, StringComparison.CurrentCultureIgnoreCase));
                        if (properties[propertyIndex] != null && !String.IsNullOrEmpty(name) && !(val is DBNull)) {
                            properties[propertyIndex].SetValue(cur, val, null);
                        }
                    }
                    foreach (var joinedEntity in JoinedEntities) {
                        var type = joinedEntity.GetType();
                        var entity = Activator.CreateInstance(type);
                        properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList();
                        propertiesCount = properties.Count();
                        values = new object[propertiesCount];
                        if (_dbAdapter.DataReader.GetValues(values) != propertiesCount) {
                            throw new Exception("Число полей в сущности не равно числу полей, возвращенных из запроса.");
                        }
                        for (j = 0; j < properties.Count(); j++) {
                            var name = _dbAdapter.DataReader.GetName(i);
                            var val = values[j];
                            var propertyIndex = properties.FindIndex(p => String.Equals(p.Name, name, StringComparison.CurrentCultureIgnoreCase));
                            if (properties[propertyIndex] != null && !String.IsNullOrEmpty(name) && !(val is DBNull)) {
                                properties[propertyIndex].SetValue(entity, val, null);
                            }
                        }
                        i += j;
                        ((IAbstractEntity) cur).JoinedEntities.Add((entity as IAbstractEntity));
                        k++;
                    }
                    
                    ret.Add(cur);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
            return ret;
        }

        public E GetJoinedEntity<E>() where E : class {
            foreach (var joinedEntity in JoinedEntities) {
                if (joinedEntity is E) {
                    return joinedEntity as E;
                }
            }
            return null;
        }
//
        public AbstractEntity<T> Where(FilterWhereCollection filterWhereCollection) {
            _filterWhere.FilterWhereCollectionCollection.Add(filterWhereCollection);
            return this;
        }
        public AbstractEntity<T> Where(List<FilterWhereCollection> filterWhereCollections) {
            _filterWhere.FilterWhereCollectionCollection.AddRange(filterWhereCollections);
            return this;
        }

        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, int value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereSimple(LogicOperator.And, field, oper, value.ToString()));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, long value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereSimple(LogicOperator.And, field, oper, value.ToString()));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, bool value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereSimple(LogicOperator.And, field, oper, value.ToString()));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, string value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereSimple(LogicOperator.And, field, oper, value));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, DateTime value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereDate(LogicOperator.And, field, oper, value));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, IEnumerable<int> value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString())));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, IEnumerable<long> value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString())));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, IEnumerable<bool> value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString())));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, IEnumerable<string> value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString())));
            return this;
        }
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            _filterWhere.FilterWhereBaseCollection.Add(new FilterWhereEnumerableDateTime(LogicOperator.And, field, oper, value));
            return this;
        }

        public AbstractEntity<T> Join(JoinType joinType, IAbstractEntity targetTable, RetrieveMode retrieveMode) {
            JoinedEntities.Add(targetTable);
            _filterJoin.Add(new FilterJoin {
                JoinType = joinType,
                TargetTable = targetTable,
                RetrieveMode = retrieveMode
            });
            return this;
        }
        public AbstractEntity<T> InnerJoin(IAbstractEntity targetTable, RetrieveMode retrieveMode) {
            JoinedEntities.Add(targetTable);
            _filterJoin.Add(new FilterJoin {
                JoinType = JoinType.Inner,
                TargetTable = targetTable,
                RetrieveMode = retrieveMode
            });
            return this;
        }
        public AbstractEntity<T> On(List<JoinCondition> joinConditions) {
            _filterJoin.Last().JoinConditions.AddRange(joinConditions);
            return this;
        }
        public AbstractEntity<T> On(JoinCondition joinCondition) {
            _filterJoin.Last().JoinConditions.Add(joinCondition);
            return this;
        }
        public AbstractEntity<T> On(Enum fieldFrom, PredicateCondition oper, Enum fieldTarget) {
            _filterJoin.Last().JoinConditions.Add(new JoinCondition {
                FieldFrom = fieldFrom,
                Oper = oper,
                FieldTarget = fieldTarget
            });
            return this;
        }

        public AbstractEntity<T> OrderBy(Enum field, OrderType orderType) {
            _filterOrder.Add(new FilterOrder(field, orderType));
            return this;
        }

        /// <summary>
        /// Добавляет SET к UPDATE
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AbstractEntity<T> Set(Enum field, object value) {
            _filterSet.Add(new FilterSet(field, value));
            return this;
        }

        /// <summary>
        /// Добавляет SET к UPDATE
        /// </summary>
        /// <param name="filterSet"></param>
        /// <returns></returns>
        public AbstractEntity<T> Set(FilterSet filterSet) {
            _filterSet.Add(filterSet);
            return this;
        }

        /// <summary>
        /// Добавляет набор SET к UPDATE
        /// </summary>
        /// <param name="filterSet"></param>
        /// <returns></returns>
        public AbstractEntity<T> Set(IEnumerable<FilterSet> filterSet) {
            _filterSet.AddRange(filterSet);
            return this;
        }

        private void TranslateWhere() {
            _query += _filterWhere.TranslateToSql(true);
            _filterWhere = new FilterWhereCollection();
        }

        private void TranslateJoin() {
            if (!_filterJoin.Any()) {
                return;
            }
            var join = string.Empty;
            foreach (var filterJoin in _filterJoin) {
                join += filterJoin.JoinType.GetJoinType() + "JOIN " + filterJoin.TargetTable.TableName + " ON ";
                var joinCondition = filterJoin.JoinConditions.First();
                join += filterJoin.TargetTable.TableName + "." + joinCondition.FieldTarget + joinCondition.Oper.GetPredicateCondition() + joinCondition.FieldFrom.GetType().DeclaringType.Name + "." + joinCondition.FieldFrom + " ";
                for (var i = 1; i < filterJoin.JoinConditions.Count; i++) {
                    joinCondition = filterJoin.JoinConditions[i];
                    join += "AND " + filterJoin.TargetTable.TableName + "." + joinCondition.FieldTarget + joinCondition.Oper.GetPredicateCondition() + joinCondition.FieldFrom.GetType().DeclaringType.Name + "." + joinCondition.FieldFrom + " ";
                }
            }
            _query += join;
            _filterJoin = new List<FilterJoin>();
        }

        private void TranslateOrder() {
            if (!_filterOrder.Any()) {
                return;
            }
            var order = "ORDER BY ";
            var firstOrder = _filterOrder.First();
            order += firstOrder.Field.GetType().DeclaringType.Name + "." + firstOrder.Field + " " + firstOrder.OrderType + " ";
            for (var i = 1; i < _filterOrder.Count; i++) {
                var curOrder = _filterOrder[i];
                order += ", " + curOrder.Field.GetType().DeclaringType.Name + "." + curOrder.Field + " " + curOrder.OrderType + " ";
            }
            _query += order;
            _filterOrder = new List<FilterOrder>();
        }

        private void TranslateSet() {
            if (!_filterSet.Any()) {
                return;
            }
            var set = "SET ";
            var firstSet = _filterSet.First();
            set += firstSet.Field + " = '" + firstSet.Value + "'";
            for (var i = 1; i < _filterSet.Count; i++) {
                var curSet = _filterSet[i];
                set += ", " + curSet.Field + " = '" + curSet.Value + "'";
            }
            _query += set;
            _filterSet = new List<FilterSet>();
        }
    }
}