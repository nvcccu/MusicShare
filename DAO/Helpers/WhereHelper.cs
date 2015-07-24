using System;
using System.Collections.Generic;
using System.Linq;
using DAO.Enums;
using DAO.Filters.Where;

namespace DAO.Helpers {
    public static class WhereHelper {
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, int value) {
            return new FilterWhereSimple(LogicOperator.And, field, oper, value.ToString());
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, long value) {
            return new FilterWhereSimple(LogicOperator.And, field, oper, value.ToString());
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, string value) {
            return new FilterWhereSimple(LogicOperator.And, field, oper, value);
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, DateTime value) {
            return new FilterWhereDate(LogicOperator.And, field, oper, value);
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, IEnumerable<int> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, IEnumerable<long> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, IEnumerable<string> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.And, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase Where(Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            return new FilterWhereEnumerableDateTime(LogicOperator.And, field, oper, value);
        }

        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, int value) {
            return new FilterWhereSimple(LogicOperator.Or, field, oper, value.ToString());
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, long value) {
            return new FilterWhereSimple(LogicOperator.Or, field, oper, value.ToString());
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, string value) {
            return new FilterWhereSimple(LogicOperator.Or, field, oper, value);
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, DateTime value) {
            return new FilterWhereDate(LogicOperator.Or, field, oper, value);
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, IEnumerable<int> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.Or, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, IEnumerable<long> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.Or, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, IEnumerable<string> value) {
            return new FilterWhereEnumerableSimple(LogicOperator.Or, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            return new FilterWhereEnumerableDateTime(LogicOperator.Or, field, oper, value);
        }

        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, int value) {
            return new FilterWhereSimple(logicOperator, field, oper, value.ToString());
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, long value) {
            return new FilterWhereSimple(logicOperator, field, oper, value.ToString());
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, string value) {
            return new FilterWhereSimple(logicOperator, field, oper, value);
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, DateTime value) {
            return new FilterWhereDate(logicOperator, field, oper, value);
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<int> value) {
            return new FilterWhereEnumerableSimple(logicOperator, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<long> value) {
            return new FilterWhereEnumerableSimple(logicOperator, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<string> value) {
            return new FilterWhereEnumerableSimple(logicOperator, field, oper, value.Select(v => v.ToString()));
        }
        public static FilterWhereBase OrWhere(LogicOperator logicOperator, Enum field, PredicateCondition oper, IEnumerable<DateTime> value) {
            return new FilterWhereEnumerableDateTime(logicOperator, field, oper, value);
        }
    }
}