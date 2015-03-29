using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using DAO.Enums;
using Npgsql;

namespace DAO {
    public interface IAbstractEntity {
        string TableName { get; set; }
        List<IAbstractEntity> JoinedEntities { get; set; }
        void Insert();
    }

    /// <summary>
    /// Шаблон для класса-сущности таблицы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractEntity<T> : IAbstractEntity where T: new() {
        /// <summary>
        /// Адаптер доступа к базе
        /// </summary>
        private readonly DbAdapter _dbAdapter;

        /// <summary>
        /// Название таблицы, на которую смотрит
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Содержит набор where условий
        /// </summary>
        private List<FilterWhere> _filterWhere;
        
        /// <summary>
        /// Содержит набор SET для апдейта
        /// </summary>
        private List<FilterSet> _filterSet;

        /// <summary>
        /// набор join'ов
        /// </summary>
        private List<FilterJoin> _filterJoin;

        /// <summary>
        /// набор сортировок
        /// </summary>
        private List<FilterOrder> _filterOrder;

        public List<IAbstractEntity> JoinedEntities { get; set; }

        /// <summary>
        /// sql-запрос
        /// </summary>
        private string _query;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="tableName"></param>
        protected AbstractEntity(string tableName) {
            _dbAdapter = new DbAdapter();
            TableName = tableName;
            _filterWhere = new List<FilterWhere>();
            _filterOrder = new List<FilterOrder>();
            _filterJoin = new List<FilterJoin>();
            _filterSet = new List<FilterSet>();
            JoinedEntities = new List<IAbstractEntity>();
        }

        public AbstractEntity<T> Update() {
            _query = "UPDATE " + TableName + " ";
            return this;
        }

        /// <summary>
        /// Сохраняет сущность в базу БЕЗ АЙДИШКИ
        /// </summary>
        public void Insert() {
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
                propValue = Convert.ToString(property.GetValue(this, null), CultureInfo.InvariantCulture);
                _query += propValue.IsNullOrEmpty() ? "NULL, " : ("'" + propValue.Replace("'", "''") + "', ");
            }
            property = properties[properties.Count() - 1];
            propValue = Convert.ToString(property.GetValue(this, null), CultureInfo.InvariantCulture);
            _query += propValue.IsNullOrEmpty() ? "NULL" : ("'" + propValue.Replace("'", "''") + "'");
            _query += ")";
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
        /// Сохраняет сущность в базу С АЙДИШКОЙ
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
                propValue = Convert.ToString(property.GetValue(this, null), CultureInfo.InvariantCulture);
                _query += propValue.IsNullOrEmpty() ? "NULL, " : ("'" + propValue.Replace("'", "''") + "', ");
            }
            property = properties[properties.Count() - 1];
            propValue = Convert.ToString(property.GetValue(this, null), CultureInfo.InvariantCulture);
            _query += propValue.IsNullOrEmpty() ? "NULL" : ("'" + propValue.Replace("'", "''") + "'");
            _query += ") RETURNING " + properties.First().Name + ";";
            Console.WriteLine(_query);
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            _dbAdapter.OpenConnection();
            try {
                var q = _dbAdapter.Command.ExecuteScalar();
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
        /// Выполняет запрос здесь и сейчас без ожидания результата
        /// </summary>
        private void RunScript() {
            _dbAdapter.OpenConnection();
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            try {
                _dbAdapter.Command.ExecuteScalar();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
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
        /// todo: AHTUNG! АТТЕНШН! Последовательность столбцов в базе должна совпадать с послдеовательностью филдов в DaoEntity'е. ПОФИКСИТЬ!!
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
                    var properties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    int i;
                    int j;
                    for (i = 0; i < properties.Count(); i++) {
                        var val = _dbAdapter.DataReader.GetValue(i);
                        if (properties[i] != null && !(val is DBNull)) {
                            properties[i].SetValue(cur, val, null);
                        }
                    }
                    foreach (var joinedEntity in JoinedEntities) {
                        var type = joinedEntity.GetType();
                        var entity = Activator.CreateInstance(type);
                        properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                        for (j = 0; j < properties.Count(); j++) {
                            var val = _dbAdapter.DataReader.GetValue(j + i);
                            if (properties[j] != null && !(val is DBNull)) {
                                properties[j].SetValue(entity, val, null);
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

        /// <summary>
        /// Преобразует енамку оператора в символьное значение
        /// todo: Эта штука явно должна быть не здесь
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        private string GetMathOper(PredicateCondition oper) {
            switch (oper) {
                case PredicateCondition.Equal:
                    return " = ";
                case PredicateCondition.Greater:
                    return " > ";
                case PredicateCondition.In:
                    return " IN ";
                case PredicateCondition.NotIn:
                    return " NOT IN ";
                    // todo: лень сразу писать все операторы :-)
                default:
                    return null;
            }
        }

        /// <summary>
        /// Преобразует енамку типа джоина в символьное значение
        /// todo: Эта штука явно должна быть не здесь
        /// </summary>
        /// <param name="joinType"></param>
        /// <returns></returns>
        private string GetJoinType(JoinType joinType) {
            switch (joinType) {
                case JoinType.Cross:
                    return " CROSS ";
                case JoinType.Inner:
                    return " INNER ";
                case JoinType.Left:
                    return " LEFT ";
                case JoinType.Outer:
                    return " OUTER ";
                case JoinType.Right:
                    return " RIGHT ";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Добавляет условие where
        /// </summary>
        /// <param name="field">Контролируемый столбец</param>
        /// <param name="oper">Бинарный оператор</param>
        /// <param name="value">Конкретное значение</param>
        /// <returns></returns>
        public AbstractEntity<T> Where(Enum field, PredicateCondition oper, object value) {
            _filterWhere.Add(new FilterWhere(field, oper, value));
            return this;
        }

        /// <summary>
        /// Добавляет условие where
        /// </summary>
        /// <param name="filterWhere"></param>
        /// <returns></returns>
        public AbstractEntity<T> Where(IEnumerable<FilterWhere> filterWhere) {
            _filterWhere.AddRange(filterWhere);
            return this;
        }

        /// <summary>
        /// добавляет join
        /// </summary>
        /// <param name="joinType"></param>
        /// <param name="targetTable"></param>
        /// <param name="retrieveMode"></param>
        /// <returns></returns>
        public AbstractEntity<T> Join(JoinType joinType, IAbstractEntity targetTable, RetrieveMode retrieveMode) {
            JoinedEntities.Add(targetTable);
            _filterJoin.Add(new FilterJoin {
                JoinType = joinType,
                TargetTable = targetTable,
                RetrieveMode = retrieveMode
            });
            return this;
        }

        /// <summary>
        /// добавляет inner join
        /// todo: допаисать все остальные джоины
        /// </summary>
        /// <param name="joinType"></param>
        /// <param name="targetTable"></param>
        /// <param name="retrieveMode"></param>
        /// <returns></returns>
        public AbstractEntity<T> InnerJoin(IAbstractEntity targetTable, RetrieveMode retrieveMode) {
            JoinedEntities.Add(targetTable);
            _filterJoin.Add(new FilterJoin {
                JoinType = JoinType.Inner,
                TargetTable = targetTable,
                RetrieveMode = retrieveMode
            });
            return this;
        }

        /// <summary>
        /// добавляет к последнему джоину условия присоединения
        /// </summary>
        /// <param name="joinConditions"></param>
        /// <returns></returns>
        public AbstractEntity<T> On(List<JoinCondition> joinConditions) {
            _filterJoin.Last().JoinConditions.AddRange(joinConditions);
            return this;
        }

        /// <summary>
        /// добавляет к последнему джоину одно условие присоединения
        /// </summary>
        /// <param name="joinCondition"></param>
        /// <returns></returns>
        public AbstractEntity<T> On(JoinCondition joinCondition) {
            _filterJoin.Last().JoinConditions.Add(joinCondition);
            return this;
        }

        /// <summary>
        /// добавляет к последнему джоину одно условие присоединения
        /// </summary>
        /// <param name="fieldFrom"></param>
        /// <param name="oper"></param>
        /// <param name="fieldTarget"></param>
        /// <returns></returns>
        public AbstractEntity<T> On(Enum fieldFrom, PredicateCondition oper, Enum fieldTarget) {
            _filterJoin.Last().JoinConditions.Add(new JoinCondition {
                FieldFrom = fieldFrom,
                Oper = oper,
                FieldTarget = fieldTarget
            });
            return this;
        }

        /// <summary>
        /// добавляет условие ORDER BY
        /// </summary>
        /// <param name="field"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаляет все данные из базы
        /// </summary>
        /// <returns></returns>
        public void Truncate() {
            _query = "TRUNCATE TABLE " + TableName + ";";
            RunScript();
        }

        /// <summary>
        /// Приводит правое значение к соответствующему условию виду
        /// </summary>
        /// <returns></returns>
        private string PrepareTargetValue(PredicateCondition predicateCondition, object value) {
            if (predicateCondition == PredicateCondition.In || predicateCondition == PredicateCondition.NotIn) {
                if (value is IEnumerable) {
                    var result = "(";
                    IEnumerable valueList = ((IEnumerable)value);
                    foreach (var val in valueList) {
                        result = result + " '" + val.ToString() + "', ";
                    }
                    return result.Substring(0, result.Length - 2) + ")";
                } else {
                    throw new Exception("Недопустимый аргумент для перечисления в IN");
                }
            }
            else {
                return "'" + value + "' ";
            }
        }

        /// <summary>
        /// Транслирует все условия where в SQL
        /// </summary>
        /// <returns></returns>
        private void TranslateWhere() {
            if (!_filterWhere.Any()) {
                return;
            }
            var where = "WHERE ";
            var field = _filterWhere.First().Field;
            where += field.GetType().DeclaringType.Name + "." + field + GetMathOper(_filterWhere.First().Oper) + 
                     PrepareTargetValue(_filterWhere.First().Oper, _filterWhere.First().Value);
            for (var i = 1; i < _filterWhere.Count; i++) {
                field = _filterWhere[i].Field;
                where += "AND " + field.GetType().DeclaringType.Name + "." + field + GetMathOper(_filterWhere[i].Oper) +
                         PrepareTargetValue(_filterWhere[i].Oper, _filterWhere[i].Value);
            }
            _query += where;
            _filterWhere = new List<FilterWhere>();
        }

        /// <summary>
        /// транслирует join в sql
        /// </summary>
        private void TranslateJoin() {
            if (!_filterJoin.Any()) {
                return;
            }
            var join = string.Empty;
            foreach (var filterJoin in _filterJoin) {
                join += GetJoinType(filterJoin.JoinType) + "JOIN " + filterJoin.TargetTable.TableName + " ON ";
                var joinCondition = filterJoin.JoinConditions.First();
                join += filterJoin.TargetTable.TableName + "." + joinCondition.FieldTarget + GetMathOper(joinCondition.Oper) + joinCondition.FieldFrom.GetType().DeclaringType.Name + "." + joinCondition.FieldFrom + " ";
                for (var i = 1; i < filterJoin.JoinConditions.Count; i++) {
                    joinCondition = filterJoin.JoinConditions[i];
                    join += "AND " + filterJoin.TargetTable.TableName + "." + joinCondition.FieldTarget + GetMathOper(joinCondition.Oper) + joinCondition.FieldFrom.GetType().DeclaringType.Name + "." + joinCondition.FieldFrom + " ";
                }
            }
            _query += join;
            _filterJoin = new List<FilterJoin>();
        }

        /// <summary>
        /// транслирует все условия ORDER BY в sql
        /// </summary>
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

        /// <summary>
        /// транслирует все условия SET в sql
        /// </summary>
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

    /// <summary>
    /// Типы join'ов
    /// </summary>
    public enum JoinType : short {
        Inner,
        Left,
        Right,
        Outer,
        Cross
    }

    /// <summary>
    /// Настройки извлечения данных присоединенных сущностей
    /// </summary>
    public enum RetrieveMode : short {
        /// <summary>
        /// Извлекать данные присоединенных сущностей
        /// </summary>
        Retrieve,

        /// <summary>
        /// Не извлекать данные присоединенных сущностей
        /// </summary>
        NonRetrieve
    }

    public class JoinCondition {
        /// <summary>
        /// Поле исходной таблицы
        /// </summary>
        public Enum FieldFrom { get; set; }

        /// <summary>
        /// Оператор проверки в предикате
        /// </summary>
        public PredicateCondition Oper { get; set; }

        /// <summary>
        /// Поле целевой таблицы
        /// </summary>
        public Enum FieldTarget { get; set; }

    }

    /// <summary>
    /// тип сортировки
    /// </summary>
    public enum OrderType : short {
        /// <summary>
        /// по возрастанию
        /// </summary>
        /// 
        Asc = 0,

        /// <summary>
        /// по убыванию
        /// </summary>
        Desc = 1
    }

    /// <summary>
    /// сортировка
    /// </summary>
    public class FilterOrder {
        /// <summary>
        /// сортируемое поле
        /// </summary>
        public Enum Field;

        /// <summary>
        /// тип сортировки
        /// </summary>
        public OrderType OrderType;

        public FilterOrder(Enum field, OrderType orderType) {
            Field = field;
            OrderType = orderType;
        }
    }

    /// <summary>
    /// Джоин к таблице
    /// </summary>
    public class FilterJoin {
        /// <summary>
        /// Тип join'а
        /// </summary>
        public JoinType JoinType { get; set; }

        /// <summary>
        /// К чему осуществляется join
        /// </summary>
        public IAbstractEntity TargetTable { get; set; }

        /// <summary>
        /// Условия join'а
        /// </summary>
        public List<JoinCondition> JoinConditions { get; set; }

        /// <summary>
        /// извлекать ли присоединенные сущности
        /// </summary>
        public RetrieveMode RetrieveMode { get; set; }

        public FilterJoin() {
            JoinConditions = new List<JoinCondition>();
        }
    }

    public class FilterWhere {
        /// <summary>
        /// 
        /// </summary>
        public Enum Field { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PredicateCondition Oper { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; private set; }

        public FilterWhere(Enum field, PredicateCondition oper, object value) {
            Field = field;
            Oper = oper;
            Value = value;
        }
    }

    public class FilterSet {
        /// <summary>
        /// 
        /// </summary>
        public Enum Field { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; private set; }

        public FilterSet(Enum field, Object value) {
            Field = field;
            Value = value;
        }
    }

    public class Conditions {
        /// <summary>
        /// 
        /// </summary>
        private List<FilterWhere> _conditionsWhere;

        Conditions() {
            _conditionsWhere = new List<FilterWhere>();
        }
    }
}