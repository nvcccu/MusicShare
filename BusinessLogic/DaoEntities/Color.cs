﻿using System;
using Core.TransportTypes;
using DAO;
using DAO.Attributes;

namespace BusinessLogic.DaoEntities {
    public class Color : AbstractEntity<Color> {
        public Color(string tableName) : base(tableName) {}

        public Color() : base("Color") { }

        public enum Fields {
            [DbType(typeof(Int32))]
            Id,
            [DbType(typeof (string))]
            Name,
            [DbType(typeof (string))]
            ImagePreview,
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePreview { get; set; }

        public ColorTransportType ToTransport() {
            return new ColorTransportType {
                Id = Id,
                Name = Name,
                ImagePreview = ImagePreview
            };
        }
    }
}