using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface IArticleProvider {
        int SaveArticle(ArticleDto article);
        ArticleDto GetArticleById(int id);
        List<ArticleDto> GetArticleByDateDesc(int count, int from);
    }
}
