using System;
using System.Collections.Generic;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereEnumerableSimple : FilterWhereBase {
        private IEnumerable<string> Value { get; set; }
        public FilterWhereEnumerableSimple(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<string> value) {
            LogicOperator = logicOperator;
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}{1}.{2} {3} {4} ";
        }
        private string ValueToString() {
            return "(" + String.Join(", ", Value) + ") ";
        }
        public override string TranslateToSql(bool isFirst) {
            return String.Format(StringFormat, isFirst ? String.Empty : LogicOperator.GetLogicOperator() + " ", Field.GetType().DeclaringType.Name, Field, Oper.GetPredicateCondition(),
                ValueToString());
        }
    }
}