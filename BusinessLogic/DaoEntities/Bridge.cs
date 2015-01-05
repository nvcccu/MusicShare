using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Bridge : AbstractEntity<Bridge> {
        public Bridge(string tableName) : base(tableName) {}

        public Bridge() : base("Bridge") {}

        public enum Fields {
            [DbType(typeof (Int32))]
            Id,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof(string))]
            ImagePreview,
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePreview { get; set; }

        public BridgeTransportType ToTransport() {
            return new BridgeTransportType {
                Id = Id,
                Name = Name,
                ImagePreview = ImagePreview
            };
        }
    }
}