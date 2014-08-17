using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class SearchProvider : ISearchProvider {
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
    }
}