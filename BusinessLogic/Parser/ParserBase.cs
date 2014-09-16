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

        protected abstract short GetBrand(object obj);
        protected abstract short GetColor(object obj);
        protected abstract short GetForm(object obj);
        protected abstract string GetImage(object obj);

        protected abstract void GetData();

        private void ActualizeItems() {
            Items.ForEach(i => new Guitar {
                Brand = GetBrand(i),
                Color = GetColor(i),
                Form = GetForm(i),
                Image = GetImage(i),
            }.Save());
            
        }
    }
}