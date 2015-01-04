﻿using System;
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
            [DbType(typeof (Int32))] Id,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof (string))] Name,

            /// <summary>
            /// 
            /// </summary>
            [DbType(typeof(string))]
            ImagePreview,
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ImagePreview { get; set; }

        public FormTransportType ToTransport() {
            return new FormTransportType {
                Id = Id,
                Name = Name,
                ImagePreview = ImagePreview
            };
        }
    }
}