using System;
using DAO.Enums;

namespace DAO.Filters.Where {
    public abstract class FilterWhereBase {
        protected LogicOperator LogicOperator { get; set; }
        protected Enum Field { get; set; }
        protected PredicateCondition Oper { get; set; }
        protected string StringFormat;
        public abstract string TranslateToSql(bool isFirst);
    }
}