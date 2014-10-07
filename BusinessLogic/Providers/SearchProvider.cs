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
                .On(GuitarWithColor.Fields.GuitarWithModelId, PredicateCondition.Equal, Guitar.Fields.Id)
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
        public List<GuitarSummaryTransportType> GetGuitarsSummary() {
            var allGuitars = new GuitarWithColor()
                .Select()
                .InnerJoin(new ColorFull(), RetrieveMode.NonRetrieve)
                .On(GuitarWithColor.Fields.ColorFullId, PredicateCondition.Equal, ColorFull.Fields.Id)
                .InnerJoin(new ColorSimple(), RetrieveMode.NonRetrieve)
                .On(ColorFull.Fields.ColorSimpleId, PredicateCondition.Equal, ColorSimple.Fields.Id)
                .InnerJoin(new GuitarWithModel(), RetrieveMode.NonRetrieve)
                .On(GuitarWithColor.Fields.GuitarWithModelId, PredicateCondition.Equal, GuitarWithModel.Fields.Id)
                .InnerJoin(new Guitar(), RetrieveMode.NonRetrieve)
                .On(GuitarWithModel.Fields.GuitarId, PredicateCondition.Equal, Guitar.Fields.Id)
                .InnerJoin(new Brand(), RetrieveMode.NonRetrieve)
                .On(Guitar.Fields.BrandId, PredicateCondition.Equal, Brand.Fields.Id)
                .InnerJoin(new Form(), RetrieveMode.NonRetrieve)
                .On(Guitar.Fields.FormId, PredicateCondition.Equal, Form.Fields.Id)
                .OrderBy(GuitarWithColor.Fields.Id, OrderType.Asc)
                .OrderBy(GuitarWithColor.Fields.ColorFullId, OrderType.Asc)
                .GetData();
            return allGuitars.Select(ag => {
                var brand = ag.GetJoinedEntity<Brand>();
                var form = ag.GetJoinedEntity<Form>();
                var colorFullName = ag.GetJoinedEntity<ColorFull>().Name;
                var guitarModel = ag.GetJoinedEntity<GuitarWithModel>().Id;
                return new GuitarSummaryTransportType {
                    GuitarWithColorId = ag.Id,
                    ImageUrl = ag.PhotoUrl,
                    BrandId = brand.Id,
                    BrandName = brand.Name,
                    FormId = form.Id,
                    FormName = form.Name,
                    ColorFullId = ag.ColorFullId,
                    ColorFullName = colorFullName,
                    ModelId = guitarModel,
                    Available = true,
                    IsGreatQualityPhoto = ag.IsGreatQualityPhoto
                };
            }).ToList();
        }

        /// <summary>
        /// Сохраняет данные о гитаре
        /// </summary>
        /// <param name="guitarSummary"></param>
        /// <returns>true если данные непротиворечивы</returns>
        public bool SaveGuitarSummary(GuitarSummaryTransportType guitarSummary) {
            var guitarIdData = new Guitar()
                .Select()
                .Where(Guitar.Fields.BrandId, PredicateCondition.Equal, guitarSummary.BrandId)
                .Where(Guitar.Fields.FormId, PredicateCondition.Equal, guitarSummary.FormId)
                .GetData()
                .ToList();
            if (!guitarIdData.Any()) {
                return false;
            }
            var guitarId = guitarIdData.First()
                .Id;
            var guitarWithModelData = new GuitarWithModel()
               .Select()
               .InnerJoin(new Guitar(), RetrieveMode.NonRetrieve)
               .On(GuitarWithModel.Fields.GuitarId, PredicateCondition.Equal, Guitar.Fields.Id)
               .Where(GuitarWithModel.Fields.Id, PredicateCondition.Equal, guitarSummary.ModelId)
               .Where(Guitar.Fields.Id, PredicateCondition.Equal, guitarId)
               .GetData()
               .ToList();

            // на случай поиска gibson superstrat-tx-hzchto
            if (!guitarWithModelData.Any()) {
                return false;
            }
            var guitarWithModel = guitarWithModelData.First();

            new GuitarWithColor()
            .Update()
            .Set(GuitarWithColor.Fields.ColorFullId, guitarSummary.ColorFullId)
            .Set(GuitarWithColor.Fields.PhotoUrl, guitarSummary.ImageUrl)
            .Set(GuitarWithColor.Fields.IsGreatQualityPhoto, guitarSummary.IsGreatQualityPhoto)
            .Set(GuitarWithColor.Fields.GuitarWithModelId, guitarSummary.ModelId)
            .Where(GuitarWithColor.Fields.Id, PredicateCondition.Equal, guitarSummary.GuitarWithColorId)
            .ExecuteScalar();
            new GuitarWithModel()
            .Update()
            .Set(GuitarWithModel.Fields.GuitarId, guitarId)
            .Set(GuitarWithModel.Fields.Model, guitarWithModel.Model)
            .Where(GuitarWithModel.Fields.Id, PredicateCondition.Equal, guitarSummary.ModelId)
            .ExecuteScalar();

            return true;
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
        public List<ColorSimpleTransportType> GetAllSimpleColors() {
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
        public List<ColorFullTransportType> GetAllFullColors() {
            return new ColorFull()
                .Select()
                .GetData()
                .Select(b => b.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GuitarTransportType> GetAllGuitars() {
            return new Guitar()
                .Select()
                .GetData()
                .Select(b => b.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GuitarWithModelTransportType> GetAllGuitarsWithModel() {
            return new GuitarWithModel()
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