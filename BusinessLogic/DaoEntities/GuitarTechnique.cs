using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class GuitarTechnique : AbstractEntity<GuitarTechnique> {
        public GuitarTechnique(string tableName) : base(tableName) { }

        public GuitarTechnique() : base("GuitarTechnique") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            ShortName
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public GuitarTechniqueDto ToDto() {
            return new GuitarTechniqueDto {
                Id = Id,
                Name = Name,
                ShortName = ShortName
            };
        }
    }
}