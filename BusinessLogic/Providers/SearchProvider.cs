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
        /// <param name="formId"></param>
        /// <param name="simpleColorId"></param>
        /// <returns></returns>
        public List<GuitarWithColorTransportType> GetSampleGuitars(int? brandId, int? formId, int? simpleColorId) {
            var sample = new GuitarWithColor()
                .Select()
                .InnerJoin(new ColorFull(), RetrieveMode.NonRetrieve)
                .On(GuitarWithColor.Fields.ColorFullId, PredicateCondition.Equal, ColorFull.Fields.Id)
                .InnerJoin(new ColorSimple(), RetrieveMode.NonRetrieve)
                .On(ColorFull.Fields.ColorSimpleId, PredicateCondition.Equal, ColorSimple.Fields.Id)
                .InnerJoin(new Guitar(), RetrieveMode.NonRetrieve)
                .On(GuitarWithColor.Fields.GuitarId, PredicateCondition.Equal, Guitar.Fields.Id)
                .InnerJoin(new Brand(), RetrieveMode.NonRetrieve)
                .On(Guitar.Fields.BrandId, PredicateCondition.Equal, Brand.Fields.Id)
                .InnerJoin(new Form(), RetrieveMode.NonRetrieve)
                .On(Guitar.Fields.FormId, PredicateCondition.Equal, Form.Fields.Id);
            AddWhereIfNotNull(sample, Brand.Fields.Id, PredicateCondition.Equal, brandId);
            AddWhereIfNotNull(sample, Form.Fields.Id, PredicateCondition.Equal, formId);
            AddWhereIfNotNull(sample, ColorSimple.Fields.Id, PredicateCondition.Equal, simpleColorId);
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
                .Select(sh => sh.ToTransport())
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