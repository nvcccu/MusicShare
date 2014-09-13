using BusinessLogic.DaoEntities;

namespace BusinessLogic.Parser {
    public interface IParser {
     
        short GetBrand();
        short GetColor();
        short GetForm();
        string GetImage();

        void GetSource();
        void Parse();

        void ActualizeDataBase();
    }

    public abstract class ParserBase {
        public abstract short GetBrand();

        public void Actualize() {
            new Guitar {
                Brand = GetBrand(),
            }.Save();
        }
    }
}