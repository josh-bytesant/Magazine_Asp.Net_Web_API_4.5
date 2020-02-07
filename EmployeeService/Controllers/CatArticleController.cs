using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class CatArticleController : BaseApiController
    {
        

        public HttpResponseMessage Get(short categoryid)
        {
            HttpResponseMessage msg = null;
            var results = entities.Articles.Include("Article_Category1")
                                           .Where(m => m.Article_Category1.Code == categoryid)
                                           .ToList()
                                           .Select(m => TheCategoryFactory.Create(m));



            if (results == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found here");
            }
            else
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, results);
            }

            return msg;
        }

        public HttpResponseMessage Get(int categoryid, int id)
        {
            HttpResponseMessage msg = null;
            var result = entities.Articles.Include("Article_Category1")
                                          .Where(m => m.AutoID == id)
                                          .FirstOrDefault();
            if (result == null)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found here");
               
            }
            else if(result.Article_Category1.Code == categoryid)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, TheCategoryFactory.Create(result));
            }
            return msg;
        }
    }
}
