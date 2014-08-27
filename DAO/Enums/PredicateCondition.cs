namespace DAO.Enums
{
    /// <summary>
    /// Бинарные операторы в условии Where
    /// </summary>
    public enum PredicateCondition {
        /// <summary>
        /// Равно =
        /// </summary>
        Equal,

        /// <summary>
        /// Не равно <>
        /// </summary>
        NotEqual,

        /// <summary>
        /// Больше >
        /// </summary>
        Greater,

        /// <summary>
        /// Меньше <
        /// </summary>
        Less,

        /// <summary>
        /// Больше или равно >=
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// Меньше или равно <=
        /// </summary>
        LessOrEqual,

        /// <summary>
        /// Условие вхождения IN
        /// </summary>
        In,

        /// <summary>
        /// Условие невхождения NOT IN
        /// </summary>
        NotIn,

        /// <summary>
        /// условие вхождение строки LIKE
        /// </summary>
        Like
    }
}