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
        /// <param name="brandId"></param>
        /// <param name="formId"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public List<GuitarTransportType> Search(int brandId, int formId, int color) {
            return new Guitar()
                .Select()
                .Where(Guitar.Fields.BrandId, PredicateCondition.Equal, brandId)
                .Where(Guitar.Fields.FormId, PredicateCondition.Equal, formId)
                .GetData()
                .Select(g => g.ToTransport())
                .ToList();
        }

        private void AddWhereIfNotNull<T>(AbstractEntity<T> ds, Enum field, PredicateCondition oper, object value)
            where T : new() {
            if (value != null) {
                ds.Where(field, oper, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="form"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public List<GuitarTransportType> GetSampleGuitars(int? brandId, int? form, int? color) {
            var sample = new Guitar().Select();
            AddWhereIfNotNull(sample, Guitar.Fields.BrandId, PredicateCondition.Equal, brandId);
            AddWhereIfNotNull(sample, Guitar.Fields.FormId, PredicateCondition.Equal, form);
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
        public List<ColorSimpleTransportType> GetAllColor() {
            return new ColorSimple()
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