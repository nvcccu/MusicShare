using System;

namespace DAO.Filters.Set {
    public class FilterSet {
        public Enum Field { get; private set; }
        public object Value { get; private set; }
        public FilterSet(Enum field, Object value) {
            Field = field;
            Value = value;
        }
    }
}