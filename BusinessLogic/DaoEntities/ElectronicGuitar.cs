using System;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    internal class ElectronicGuitar : AbstractEntity<ElectronicGuitar> {
        public ElectronicGuitar(string tableName) : base(tableName) {}

        public ElectronicGuitar() : base("ElectronicGuitar") { }

        public enum Fields {
            [DbType(typeof(Int64))]
            Id = 0,

            [DbType(typeof(string))]
            Brand = 1,

            [DbType(typeof(string))]
            Model = 2,

            [DbType(typeof(string))]
            Color = 3,

            [DbType(typeof(string))]
            Form = 4,

            [DbType(typeof(string))]
            BodyMaterial = 5,

            [DbType(typeof(string))]
            NeckMaterial = 6,

            [DbType(typeof(string))]
            PickGuard = 7,

            [DbType(typeof(decimal))]
            Mensuration = 8,

            [DbType(typeof(string))]
            TremoloSystem = 9,

            [DbType(typeof(string))]
            PickUp = 10,

            [DbType(typeof(string))]
            Electronic = 11,

            [DbType(typeof(string))]
            Pin = 12,

            [DbType(typeof(bool))]
            IsLeftHand = 13,

            [DbType(typeof(bool))]
            AvailableNow = 14,

            [DbType(typeof(string))]
            Image = 15,

            [DbType(typeof(decimal))]
            Price = 16,

            [DbType(typeof(string))]
            Url = 17
        };

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BodyMaterial{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NeckMaterial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PickGuard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Mensuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TremoloSystem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PickUp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Electronic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLeftHand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AvailableNow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
    }
}