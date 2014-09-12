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
            return new Guitar()
                .Select()
                .Where(Guitar.Fields.Brand, PredicateCondition.Equal, brand)
                .Where(Guitar.Fields.Form, PredicateCondition.Equal, form)
                .Where(Guitar.Fields.Color, PredicateCondition.Equal, color)
                .GetData()
                .Select(g => g.ToTransport())
                .ToList();
        }

        private void AddWhereIfNotNull<T>(AbstractEntity<T> ds, Enum field, PredicateCondition oper, object value) where T : new()  {
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
        public List<GuitarTransportType> GetSampleGuitars(short? brand, short? form, short? color) {
            var sample = new SampleGuitar().Select();
            AddWhereIfNotNull(sample, Guitar.Fields.Brand, PredicateCondition.Equal, brand);
            AddWhereIfNotNull(sample, Guitar.Fields.Form, PredicateCondition.Equal, form);
            AddWhereIfNotNull(sample, Guitar.Fields.Color, PredicateCondition.Equal, color);
            return sample
                .GetData()
                .Select(g => g.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SearchHintTransportType> GetSearchHints() {
            return new SearchHint().Select()
                .GetData()
                .Select(h => h.ToTransport())
                .ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<NewsTransportType> GetLastNews() {
            return new News()
                .Select()
                .GetData()
                .Select(n => n.ToTransport())
                .ToList();
        }
    }
}