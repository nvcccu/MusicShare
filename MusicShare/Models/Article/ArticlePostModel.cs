using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;

namespace MusicShareWeb.Models.Article {
    public class ArticlePostModel {
        public string Title { get; set; }
        public string Text { get; set; }

        public int Save(int authorId) {
            return ServiceManager<IBusinessLogic>.Instance.Service.SaveArticle(new ArticleDto {
                Title = Title,
                Text = Text,
                AuthorId = authorId
            });
        }
    }
}