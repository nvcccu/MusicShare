using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Article {
    public class ArticleModel : BaseModel {
        public ArticleDto Article { get; set; }
        public AccountDto Author { get; set; }

        public ArticleModel(BaseModel baseModel) : base(baseModel) {}
        public ArticleModel(BaseModel baseModel, int id) : base(baseModel) {
            Article = ServiceManager<IBusinessLogic>.Instance.Service.GetArticleById(id);
            Author = ServiceManager<IBusinessLogic>.Instance.Service.GetUser(Article.AuthorId);
        }
    }
}