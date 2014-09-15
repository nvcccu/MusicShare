using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using DAO;

namespace BusinessLogic.Helpers {
    public static class ColorHelper {
        private static Dictionary<short, string> _colors;

        public static Dictionary<short, string> Colors {
            get {
                return _colors ?? (_colors = new Color()
                    .Select()
                    .OrderBy(Color.Fields.Id, OrderType.Asc)
                    .GetData()
                    .ToDictionary(c => c.Id, c => c.Code));
            }
        }
    }
}