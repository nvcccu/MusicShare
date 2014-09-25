using System.Collections.Generic;
using BusinessLogic.DaoEntities;

namespace BusinessLogic.Parser {
    public abstract class ParserBase {
        protected List<object> Items;

        protected ParserBase() {
            Items = new List<object>();
            GetData();
            ActualizeItems();
        }

        protected abstract int GetBrand(object obj);
        protected abstract int GetColor(object obj);
        protected abstract int GetForm(object obj);
        protected abstract string GetImage(object obj);

        protected abstract void GetData();

        private void ActualizeItems() {
            Items.ForEach(i => new Guitar {
                BrandId = GetBrand(i),
                FormId = GetForm(i),
            }.Insert());
            
        }
    }
}