using System;
using DAO.Attributes;

namespace DAO {
    internal class TableEntity : AbstractEntity<TableEntity> {
        public TableEntity(string tableName) : base(tableName) {}

        public TableEntity() : base("test") { }

        public enum Fields {
            [DbType(typeof(Int64))]
            Id = 0,

            [DbType(typeof(string))]
            Data = 1,
        };

        public int Id { get; set; }

        public string Data { get; set; }

    
    }
}
