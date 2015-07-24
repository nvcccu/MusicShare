using System;
using DAO.Enums;

namespace DAO.Filters.Order {
    /// <summary>
    /// сортировка
    /// </summary>
    public class FilterOrder {
        /// <summary>
        /// сортируемое поле
        /// </summary>
        public Enum Field;
        /// <summary>
        /// тип сортировки
        /// </summary>
        public OrderType OrderType;
        public FilterOrder(Enum field, OrderType orderType) {
            Field = field;
            OrderType = orderType;
        }
    }
}