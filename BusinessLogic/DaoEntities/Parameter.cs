using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Parameter : AbstractEntity<Parameter> {
        public Parameter(string tableName) : base(tableName) {}

        public Parameter() : base("Parameter") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (Int32?))]
            ParentId,
            [DbType(typeof (string))]
            NameNominative,
            [DbType(typeof (string))]
            NameGenitive,
            [DbType(typeof (Int32?))]
            ParameterValueHeight,
            [DbType(typeof (Int32?))]
            ParameterValueWidth
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string NameNominative { get; set; }
        public string NameGenitive { get; set; }
        public int? ParameterValueHeight { get; set; }
        public int? ParameterValueWidth { get; set; }

        public ParameterDto ToDto() {
            return new ParameterDto {
                Id = Id,
                ParentId = ParentId,
                NameNominative = NameNominative,
                NameGenitive = NameGenitive,
                ParameterValueHeight = ParameterValueHeight,
                ParameterValueWidth = ParameterValueWidth
            };
        }
    }
}