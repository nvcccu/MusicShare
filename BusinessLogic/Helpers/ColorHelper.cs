using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using DAO;

namespace BusinessLogic.Helpers {
    public static class ColorHelper {
        private static Dictionary<int, string> _colors;

        public static Dictionary<int, string> Colors
        {
            get {
                return _colors ?? (_colors = new ColorSimple()
                    .Select()
                    .OrderBy(ColorSimple.Fields.Id, OrderType.Asc)
                    .GetData()
                    .ToDictionary(c => c.Id, c => c.Name));
            }
        }
    }
}