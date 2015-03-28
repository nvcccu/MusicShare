using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class IncompatibleParameter : AbstractEntity<IncompatibleParameter> {
        public IncompatibleParameter(string tableName) : base(tableName) {}

        public IncompatibleParameter() : base("IncompatibleParameter") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ParameterId,
            [DbType(typeof (Int32))]
            ParameterValueId,
            [DbType(typeof (Int32))]
            IncompatibleParameterId,
            [DbType(typeof (Int32))]
            IncompatibleParameterValueId
        }

        public int Id { get; set; }
        public int ParameterId { get; set; }
        public int ParameterValueId { get; set; }
        public int IncompatibleParameterId { get; set; }
        public int IncompatibleParameterValueId { get; set; }
       

        public IncompatibleParameterDto ToDto() {
            return new IncompatibleParameterDto {
                Id = Id,
                ParameterId = ParameterId,
                ParameterValueId = ParameterValueId,
                IncompatibleParameterId = IncompatibleParameterId,
                IncompatibleParameterValueId = IncompatibleParameterValueId
            };
        }
    }
}