using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace EmployeeService.Models
{
    public class MagazineFactory
    {
        private UrlHelper _urlHelper;
        public MagazineFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }
        public MagazineArticleListModel Create(Magazine magazine)
        {
            
            var magBoy = new MagazineArticleListModel()
            {
                Url = _urlHelper.Link("Magazine", new {magazineid = magazine.AutoID } ),
                Id = magazine.AutoID,
                Title = magazine.Title,
                Thumbnail = magazine.Thumbnail_Name,
                CreatedDate = magazine.Created_Date,
                Articles = magazine.Articles.Select(a => Create(a))

            };
            
            return magBoy;

        }



        public ArticleListViewModel Create(Article article)
        {
            return new ArticleListViewModel()
            {
                Url = _urlHelper.Link("MagArticle", new { magazineid = article.Magazine1.AutoID, id = article.AutoID }),
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
