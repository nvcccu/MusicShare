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
        private List<FilterWhere> _conditionsWhere;

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
            _conditionsWhere = new List<FilterWhere>();
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
        private string GetMathOper(OperMath oper) {
            switch (oper) {
                case OperMath.BitwiseAnd:
                    return "&";
                case OperMath.Equal:
                    return "=";
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
        public AbstractEntity<T> Where(Enum field, OperMath oper, object value) {
            _conditionsWhere.Add(new FilterWhere(field, oper, value));
            return this;
        }

        /// <summary>
        /// Добавляет условие where
        /// </summary>
        /// <param name="filterWhere"></param>
        /// <returns></returns>
        public AbstractEntity<T> Where(IEnumerable<FilterWhere> filterWhere) {
            _conditionsWhere.AddRange(filterWhere);
            return this;
        }

        /// <summary>
        /// Транслирует все условия where в SQL
        /// </summary>
        /// <returns></returns>
        private void TranslateWhere() {
            string where = "WHERE ";
            where += _conditionsWhere.First().Field + GetMathOper(_conditionsWhere.First().Oper) + "'" +
                     _conditionsWhere.First().Value + "' ";
            for (int i = 1; i < _conditionsWhere.Count; i++) {
                where += "AND " + _conditionsWhere[i].Field + GetMathOper(_conditionsWhere[i].Oper) + "'" +
                         _conditionsWhere[i].Value + "' ";
            }
            _query += where;
            _conditionsWhere = new List<FilterWhere>();
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
        public OperMath Oper { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; private set; }

        public FilterWhere(Enum field, OperMath oper, object value) {
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