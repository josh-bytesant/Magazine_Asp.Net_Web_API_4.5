using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class MagazinesController : BaseApiController
    {
        //public MagazinesController()
        //{
        //    CategoryFactory _categoryFactory = new CategoryFactory();
        //}


       
        //[Route("~/Api/Magazines")]
        public IEnumerable<MagazineArticleListModel> Get()
        {
            var model = entities.Magazines.Include("Articles")
                                .OrderBy(a => a.Title)
                                .Take(10)
                                .Select(a => new MagazineArticleListModel()
                                {
                                    Id = a.AutoID,
                                    Title = a.Title,
                                    Thumbnail = a.Thumbnail_Name,
                                    CreatedDate = a.Created_Date,
                                    Articles = a.Articles.Select(x =>
                                    new ArticleListViewModel()
                                    {
                                        Id = x.AutoID,
                                        Title = x.Title,
                                        ArticleCategory = x.Article_Category1.Description,
                                        ExpiryDate = x.Expiry_Date,
                                        CreatedDate = x.Created_Date,
                                        Thumbnail = x.Thumbnail_Name,
                                        Video = x.Video_Name,
                                        Content = x.Content_Name
                                    })

                                });
            return model;

        }

        
        public HttpResponseMessage Get(int magazineid)
        {
            HttpResponseMessage msg = null;
            var result = entities.Magazines.Include("Articles").Where(f => f.AutoID == magazineid).FirstOrDefault();

            if (result == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found Here");
            }
            else
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, TheMagazineFactory.Create(result));
            }

            return msg;

           
            
        }





       
    }
}
