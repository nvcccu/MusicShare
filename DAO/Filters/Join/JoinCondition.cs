using System;
using DAO.Enums;

namespace DAO.Filters.Join {
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
}