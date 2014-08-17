namespace MusicShareWeb.Models {
    public class SearchQueryModel : BaseModel {
        /// <summary>
        /// 
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PriceFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PriceTo { get; set; }

        public SearchQueryModel(string brand, string form, string model, string manufacturer, string color,
            int priceFrom, int priceTo) {
            Brand = brand;
            Form = form;
            Model = model;
            Manufacturer = manufacturer;
            Color = color;
            PriceFrom = priceFrom;
            PriceTo = priceTo;
        }
    }
}