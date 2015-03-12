using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class ParameterArrow : AbstractEntity<ParameterArrow> {
        public ParameterArrow(string tableName) : base(tableName) {}

        public ParameterArrow() : base("ParameterArrow") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32))]
            ParameterId,
            [DbType(typeof (Int32?))]
            FormId,
            [DbType(typeof (Int32))]
            ArrowLeft,
            [DbType(typeof (Int32))]
            ArrowTop,
            [DbType(typeof (Int32))]
            TextLeft,
            [DbType(typeof (Int32))]
            TextTop,
            [DbType(typeof (String))]
            Url
        }

        public int Id { get; set; }
        public int ParameterId { get; set; }
        public int? FormId { get; set; }
        public int ArrowLeft { get; set; }
        public int ArrowTop { get; set; }
        public int TextLeft { get; set; }
        public int TextTop { get; set; }
        public string Url { get; set; }

        public ParameterArrowDto ToDto() {
            return new ParameterArrowDto {
                Id = Id,
                ParameterId = ParameterId,
                FormId = FormId,
                ArrowLeft = ArrowLeft,
                ArrowTop = ArrowTop,
                TextLeft = TextLeft,
                TextTop = TextTop,
                Url = Url
            };
        }
    }
}