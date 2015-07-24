using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereDate : FilterWhereBase {
        private DateTime Value { get; set; }
        public FilterWhereDate(LogicOperator logicOperator, Enum field, PredicateCondition oper, DateTime value) {
            LogicOperator = logicOperator;
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}{1}.{2} {3} '{4}' ";
        }
        private string ValueToString() {
            return String.Format("{0:yyyy-MM-dd HH:mm:ss}", Value);
        }
        public override string TranslateToSql(bool isFirst) {
            return String.Format(StringFormat, isFirst ? String.Empty : LogicOperator.GetLogicOperator() + " ", Field.GetType().DeclaringType.Name, Field, Oper.GetPredicateCondition(), ValueToString());
        }
    }
}