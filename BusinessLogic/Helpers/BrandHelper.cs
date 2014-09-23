using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using DAO;

namespace BusinessLogic.Helpers {
    public static class BrandHelper {
        private static Dictionary<int, string> _brands;

        public static Dictionary<int, string> Brands
        {
            get {
                return _brands ?? (_brands = new Brand()
                    .Select()
                    .OrderBy(Brand.Fields.Id, OrderType.Asc)
                    .GetData()
                    .ToDictionary(c => c.Id, c => c.Logo));
            }
        }
    }
}