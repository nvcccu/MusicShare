using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DaoEntities;
using BusinessLogic.Interfaces;
using Core.TransportTypes;
using DAO;
using DAO.Enums;

namespace BusinessLogic.Providers {
    public class ArticleProvider : IArticleProvider {
        public int SaveArticle(ArticleDto article) {
            return Convert.ToInt32(new Article {
                AuthorId = article.AuthorId,
                Title = article.Title,
                Text = article.Text,
                DateCreated = DateTime.Now,
                IsModerated = true,
                UpVote = 0,
                DownVote = 0,
                WatchNumber = 0
            }.Insert());
        }
        public ArticleDto GetArticleById(int id) {
            var article = new Article()
                .Select()
                .Where(Article.Fields.Id, PredicateCondition.Equal, id)
                .Where(Article.Fields.IsModerated, PredicateCondition.Equal, true)
                .GetData()
                .SingleOrDefault();
            return article != null ? article.ToDto() : null;
        }
        public List<ArticleDto> GetArticleByDateDesc(int count, int from) {
            return new Article()
                .Select()
                .Where(Article.Fields.IsModerated, PredicateCondition.Equal, true)
                .OrderBy(Article.Fields.DateCreated, OrderType.Desc)
                .GetData()
                .Skip(from - 1)
                .Take(count)
                .Select(a => a.ToDto())
                .ToList();
        }
    }
}