using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereEnumerableDateTime : FilterWhereBase {
        private IEnumerable<DateTime> Value { get; set; }
        public FilterWhereEnumerableDateTime(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            LogicOperator = logicOperator;
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}{1}.{2} {3} {4} ";
        }
        private string ValueToString() {
            return "(" + String.Join(", ", Value.Select(v => String.Format("'{0:yyyy-MM-dd HH:mm:ss}'", v))) + ") ";
        }
        public override string TranslateToSql(bool isFirst) {
            return String.Format(StringFormat, isFirst ? String.Empty : LogicOperator.GetLogicOperator() + " ", Field.GetType().DeclaringType.Name, Field, Oper.GetPredicateCondition(),
                ValueToString());
        }
    }
}