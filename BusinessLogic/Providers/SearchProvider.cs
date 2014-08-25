using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class SearchProvider : ISearchProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public List<GuitarTransportType> Search(string brand, string model, string color) {
            return new Guitar("guitar")
                .Select()
                .Where(Guitar.Fields.Brand, OperMath.Equal, brand)
                .Where(Guitar.Fields.Model, OperMath.Equal, model)
                .Where(Guitar.Fields.Color, OperMath.Equal, color)
                .GetData()
                .Select(g => g.ToTransport())
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public GuitarTransportType GetSampleGuitar(string brand, string model, string color) {
            return new Guitar("guitar")
                .Select()
                .Where(Guitar.Fields.Brand, OperMath.Equal, brand)
                .Where(Guitar.Fields.Model, OperMath.Equal, model)
                .Where(Guitar.Fields.Color, OperMath.Equal, color)
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
    }
}