namespace MusicShareWeb.Models.Article {
    public class ArticleModel : BaseModel {
        public string Title { get; set; }
        public string Text { get; set; }

        public ArticleModel(BaseModel baseModel) : base(baseModel) {}
    }
}