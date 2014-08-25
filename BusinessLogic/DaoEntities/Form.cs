using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Form : AbstractEntity<Form> {
        public Form(string tableName) : base(tableName) {}

        public Form() : base("Form") {}

        public enum Fields {
            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (Int16))] Id = 0,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Name = 1,
        }

        /// <summary>
        /// 
        /// </summary>
        public short Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        public FormTransportType ToTransport() {
            return new FormTransportType {
                Id = Id,
                Name = Name
            };
        }
    }
}