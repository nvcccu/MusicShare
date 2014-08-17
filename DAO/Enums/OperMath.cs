namespace DAO.Enums
{
    /// <summary>
    /// Бинарные операторы в условии Where
    /// </summary>
    public enum OperMath {
        /// <summary>
        /// Равно
        /// </summary>
        Equal,

        /// <summary>
        /// Не равно
        /// </summary>
        NotEqual,

        /// <summary>
        /// Больше
        /// </summary>
        Greater,

        /// <summary>
        /// Меньше
        /// </summary>
        Less,

        /// <summary>
        /// Больше или равно
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// Меньше или равно
        /// </summary>
        LessOrEqual,

        /// <summary>
        /// Битовое И
        /// </summary>
        BitwiseAnd,

        /// <summary>
        /// Битовое ИЛИ
        /// </summary>
        BitwiseOr,

        /// <summary>
        /// Условие вхождения IN
        /// </summary>
        In,

        /// <summary>
        /// Условие невхождения NOT IN
        /// </summary>
        NotIn,
    }
}