using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using DAO.Enums;
using Npgsql;

namespace DAO {
    /// <summary>
    /// Шаблон для класса-сущности таблицы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractEntity<T> where T : new() {
        /// <summary>
        /// Адаптер доступа к базе
        /// </summary>
        private readonly DbAdapter _dbAdapter;

        /// <summary>
        /// Название таблицы, на которую смотрит
        /// todo: сделать атрибутом
        /// </summary>
        private readonly string _tableName;

        /// <summary>
        /// Содержит набор where условий
        /// </summary>
        private List<FilterWhere> _filterWhere;

        /// <summary>
        /// набор join'ов
        /// </summary>
        private List<FilterJoin> _filterJoin;

        /// <summary>
        /// набор сортировок
        /// </summary>
        private List<FilterOrder> _filterOrder;

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
            _tableName = tableName;
            _filterWhere = new List<FilterWhere>();
            _filterOrder = new List<FilterOrder>();
        }

        /// <summary>
        /// Сохраняет сущность в базу
        /// </summary>
        public void Save() {
            PropertyInfo property;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            _query = "INSERT INTO " + _tableName + " (";
            for (int i = 1; i < properties.Count() - 1; i++) {
                property = properties[i];
                _query += property.Name + ", ";
            }
            _query += properties[properties.Count() - 1].Name + ") ";
            _query += "VALUES (";
            for (int i = 1; i < properties.Count() - 1; i++) {
                property = properties[i];
                _query += "'" + Convert.ToString(property.GetValue(this, null), CultureInfo.InvariantCulture) + "', ";
            }
            property = properties[properties.Count() - 1];
            _query += "'" + property.GetValue(this, null) + "'";
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
        /// Запрос на выборку
        /// todo: заменить * на явное перечисление полей
        /// todo: запилить возможность получения только нужных полей
        /// </summary>
        /// <returns></returns>
        public AbstractEntity<T> Select() {
            _query = "SELECT * FROM " + _tableName + " ";
            return this;
        }
       
        /// <summary>
        /// Получение данных из таблицы
        /// todo: запилить возможность получения только нужных полей, указание полей поместить в Select()
        /// todo: продумать, как вытащить логику обращения к базе из этого метода
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetData() {
            TranslateWhere();
            TranslateOrder();
            var ret = new List<T>();
            _dbAdapter.OpenConnection();
            _dbAdapter.Command = new NpgsqlCommand(_query, _dbAdapter.Connection);
            try {
                _dbAdapter.DataReader = _dbAdapter.Command.ExecuteReader();
                while (_dbAdapter.DataReader.Read()) {
                    var cur = new T();
                    var properties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    for (int i = 0; i < properties.Count(); i++) {
                        var val = _dbAdapter.DataReader.GetValue(i);
                        if (properties[i] != null && !(val is DBNull)) {
                            properties[i].SetValue(cur, _dbAdapter.DataReader.GetValue(i), null);
                        }
                    }
                    ret.Add(cur);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            _dbAdapter.CloseConnection();
            return ret;
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
                    return "=";
                case PredicateCondition.Greater:
                    return ">";
                    // todo: лень сразу писать все операторы :-)
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
        /// Транслирует все условия where в SQL
        /// </summary>
        /// <returns></returns>
        private void TranslateWhere() {
            if (!_filterWhere.Any()) {
                return;
            }
            string where = "WHERE ";
            where += _filterWhere.First().Field + GetMathOper(_filterWhere.First().Oper) + "'" +
                     _filterWhere.First().Value + "' ";
            for (var i = 1; i < _filterWhere.Count; i++) {
                where += "AND " + _filterWhere[i].Field + GetMathOper(_filterWhere[i].Oper) + "'" +
                         _filterWhere[i].Value + "' ";
            }
            _query += where;
            _filterWhere = new List<FilterWhere>();
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
            order += firstOrder.Field + " " + firstOrder.OrderType + " ";
            for (var i = 1; i < _filterOrder.Count; i++) {
                var curOrder = _filterOrder[i];
                order += ", " + curOrder.Field + " " + curOrder.OrderType + " ";
            }
            _query += order;
            _filterOrder = new List<FilterOrder>();
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
        Retrtieve,

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
//        public AbstractEntity TargetTable { get; set; }

        /// <summary>
        /// Условия join'а
        /// </summary>
        public List<JoinCondition> JoinConditions { get; set; }
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