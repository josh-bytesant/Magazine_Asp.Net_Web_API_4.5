using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeService.Models;

namespace EmployeeService.Controllers
{
    public class CategoriesController : BaseApiController
    {
       
        //[Route("~/Api/Articles")]
        public IEnumerable<CategoryArticleListModel> Get()
        {
            



            //var model = entities.Articles.Select(x => new ArticleListViewModel
            //{
            //Id = x.AutoID,
            //        Title = x.Title,
            //        ArticleCategory = x.Article_Category1.Description,
            //        ExpiryDate = x.Expiry_Date,
            //        CreatedDate = x.Created_Date,
            //        Thumbnail = x.Thumbnail_Name,
            //        Video = x.Video_Name,
            //        Content = x.Content_Name


            //}).ToList();
            //return model;


            var model = entities.Article_Categories.Include("Articles")
                                .OrderBy(a => a.Description)
                                .Take(10)
                                .Select(a => new CategoryArticleListModel()
                                {
                                    
                                    ArticleCategory = a.Description,
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

        
        public HttpResponseMessage Get(int categoryid)
        {
            HttpResponseMessage msg = null;
            var result = entities.Article_Categories.Include("Articles").Where(f => f.Code == categoryid).FirstOrDefault();

            if (result == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found Here");
            }
            else
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, TheCategoryFactory.Create(result));
            }

            return msg;


        }
    }
}
