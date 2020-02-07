using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace EmployeeService.Models
{
    public class CategoryFactory
    {
        private UrlHelper _urlHelper;
        public CategoryFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public CategoryArticleListModel Create(Article_Category category)
        {
            return new CategoryArticleListModel()
            {
                Url = _urlHelper.Link("Category", new { categoryid = category.Code }),
                ArticleCategory = category.Description,
                Articles = category.Articles.Select(a => Create(a))

            };
        }

        public ArticleListViewModel Create(Article article)
        {
            return new ArticleListViewModel()
            {
                Url = _urlHelper.Link("CatArticle", new { categoryid = article.Article_Category1.Code, id = article.AutoID }),
                Id = article.AutoID,
                Title = article.Title,
                ArticleCategory = article.Article_Category1.Description,
                ExpiryDate = article.Expiry_Date,
                CreatedDate = article.Created_Date,
                Thumbnail = article.Thumbnail_Name,
                Video = article.Video_Name,
                Content = article.Content_Name
            };
        }
    }
}