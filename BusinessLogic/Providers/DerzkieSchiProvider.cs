using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class DerzkieSchiProvider : IDerzkieSchiProvider {
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
                .OrderBy(GuitarWithColor.Fields.ColorFullId, OrderType.Asc)
                .GetData();
            return allGuitars.Select(ag => {
                var brand = ag.GetJoinedEntity<Brand>();
                var colorFullName = ag.GetJoinedEntity<ColorFull>().Name;
                var guitarModel = ag.GetJoinedEntity<GuitarWithModel>().Id;
                return new GuitarSummaryTransportType {
                    GuitarWithColorId = ag.Id,
                    ImageUrl = ag.PhotoUrl,
                    BrandId = brand.Id,
                    BrandName = brand.Name,
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
            var guitarId = guitarIdData.First().Id;
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
        /// сохраняет новую гитару в базу
        /// </summary>
        /// <param name="guitarSummary"></param>
        /// <returns></returns>
        public bool SaveNewGuitar(GuitarSummaryTransportType guitarSummary) {
            if (guitarSummary.ImageUrl == null) {
                return false;
            }
            var guitarIdData = new Guitar()
                .Select()
                .Where(Guitar.Fields.BrandId, PredicateCondition.Equal, guitarSummary.BrandId)
                .Where(Guitar.Fields.FormId, PredicateCondition.Equal, guitarSummary.FormId)
                .GetData()
                .ToList();
            if (!guitarIdData.Any()) {
                return false;
            }
            var guitarId = guitarIdData.First().Id;
            var guitarWithModelData = new GuitarWithModel()
                .Select()
                .InnerJoin(new Guitar(), RetrieveMode.NonRetrieve)
                .On(GuitarWithModel.Fields.GuitarId, PredicateCondition.Equal, Guitar.Fields.Id)
                .Where(GuitarWithModel.Fields.Id, PredicateCondition.Equal, guitarSummary.ModelId)
                .Where(Guitar.Fields.Id, PredicateCondition.Equal, guitarId)
                .GetData()
                .ToList();
            // на случай добавления gibson superstrat-tx-hzchto
            if (!guitarWithModelData.Any()) {
                return false;
            }
            var guitarWithModel = guitarWithModelData.First();

            new GuitarWithColor() {
                GuitarWithModelId = guitarWithModel.Id,
                ColorFullId = guitarSummary.ColorFullId,
                PhotoUrl = guitarSummary.ImageUrl,
                IsGreatQualityPhoto = guitarSummary.IsGreatQualityPhoto
            }.Insert();

            return true;
        }

        public bool UpdateGuitarModel(GuitarWithModelTransportType guitarModel) {
            new GuitarWithModel()
                .Update()
                .Set(GuitarWithModel.Fields.Model, guitarModel.Model)
                .Where(GuitarWithModel.Fields.Id, PredicateCondition.Equal, guitarModel.Id)
                .ExecuteScalar();
            return true;
        }

        public bool SaveNewGuitarModel(GuitarWithModelTransportType guitarModel) {
            new GuitarWithModel {
                GuitarId = guitarModel.GuitarId,
                Model = guitarModel.Model
            }.Insert();
            return true;
        }

        public bool UpdateGuitarColor(GuitarWithColorTransportType guitarColor) {
            return true;
        }

        public bool SaveNewGuitarColor(GuitarWithColorTransportType guitarColor) {
            return true;
        }
    }
}