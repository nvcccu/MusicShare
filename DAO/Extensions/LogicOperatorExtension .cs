using System;
using DAO.Enums;

namespace DAO.Extensions {
    public static class LogicOperatorExtension  {
        public static string GetLogicOperator(this LogicOperator oper) {
            switch (oper) {
                case LogicOperator.And:
                    return "AND";
                case LogicOperator.Or:
                    return "OR";
                default:
                    throw new Exception("Неизвестный тип логического оператора.");
            }
        }
    }
}