using System.Collections.Generic;
using DAO.Enums;

namespace DAO.Filters.Join {
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
}