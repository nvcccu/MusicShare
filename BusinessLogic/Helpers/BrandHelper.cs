using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using DAO;

namespace BusinessLogic.Helpers {
    public static class BrandHelper {
        private static Dictionary<short, long> _brands;

        public static Dictionary<short, long> Brands {
            get {
                return _brands ?? (_brands = new Brand()
                    .Select()
                    .OrderBy(Color.Fields.Id, OrderType.Asc)
                    .GetData()
                    .ToDictionary(c => c.Id, c => c.Code));
            }
        }
    }
}