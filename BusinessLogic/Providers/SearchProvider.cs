using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class SearchProvider : ISearchProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="form"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public List<GuitarTransportType> Search(short brand, short form, short color) {
            return new Guitar("guitar")
                .Select()
                .Where(Guitar.Fields.Brand, OperMath.Equal, brand)
                .Where(Guitar.Fields.Form, OperMath.Equal, form)
                .Where(Guitar.Fields.Color, OperMath.Equal, color)
                .GetData()
                .Select(g => g.ToTransport())
                .ToList();
        }

        private void AddWhereIfNotNull<T>(AbstractEntity<T> ds, Enum field, OperMath oper,  object value) where T : new()  {
            if (value != null) {
                ds.Where(field, oper, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="form"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public GuitarTransportType GetSampleGuitar(short? brand, short? form, short? color) {
            var sample = new Guitar("guitar") .Select();
            AddWhereIfNotNull(sample, Guitar.Fields.Brand, OperMath.Equal, brand);
            AddWhereIfNotNull(sample, Guitar.Fields.Form, OperMath.Equal, form);
            AddWhereIfNotNull(sample, Guitar.Fields.Color, OperMath.Equal, color);
            return sample
                .GetData()
                .Select(g => g.ToTransport())
                .ToList()
                .First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BrandTransportType> GetAllBrand() {
            return new Brand()
                .Select()
                .GetData()
                .Select(b => b.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FormTransportType> GetAllForm() {
            return new Form()
                .Select()
                .GetData()
                .Select(b => b.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ColorTransportType> GetAllColor() {
            return new Color()
                .Select()
                .GetData()
                .Select(b => b.ToTransport())
                .ToList();
        }
    }
}