using System;
using DAO.Enums;

namespace DAO.Extensions {
    public static class JoinTypeExtension  {
        public static string GetJoinType(this JoinType joinType) {
            switch (joinType) {
                case JoinType.Cross:
                    return " CROSS ";
                case JoinType.Inner:
                    return " INNER ";
                case JoinType.Left:
                    return " LEFT ";
                case JoinType.Outer:
                    return " OUTER ";
                case JoinType.Right:
                    return " RIGHT ";
                default:
                    throw new Exception("Неизвестный тип джоина.");
            }
        }
    }
}