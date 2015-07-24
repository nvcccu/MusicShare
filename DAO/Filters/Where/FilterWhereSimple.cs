using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereSimple : FilterWhereBase {
        private string Value { get; set; }
        public FilterWhereSimple(LogicOperator logicOperator, Enum field, PredicateCondition predicateCondition, string value) {
            LogicOperator = logicOperator;
            Field = field;
            Oper = predicateCondition;
            Value = value;
            StringFormat = "{0}{1}.{2} {3} '{4}' ";
        }
        private string ValueToString() {
            return Value;
        }
        public override string TranslateToSql(bool isFirst) {
            return String.Format(StringFormat, isFirst ? String.Empty : LogicOperator.GetLogicOperator() + " ", Field.GetType().DeclaringType.Name, Field, Oper.GetPredicateCondition(),
                ValueToString());
        }
    }
}