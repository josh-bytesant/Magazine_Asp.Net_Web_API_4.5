using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public class MagArticleController : BaseApiController
    {
        

        public HttpResponseMessage Get(int magazineid)
        {
            HttpResponseMessage msg = null;
            var results = entities.Articles.Include("Magazine1")
                                           .Where(m => m.Magazine1.AutoID == magazineid)
                                           .ToList()
                                           .Select(m => TheMagazineFactory.Create(m));


            
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

        public HttpResponseMessage Get(int magazineid, int id)
        {
            HttpResponseMessage msg = null;
            var result = entities.Articles.Include("Magazine1")
                                          .Where(m => m.AutoID == id)
                                          .FirstOrDefault();
            Article artMan = new Article();
            //if (result == null && result.Magazine1.AutoID != id && result.AutoID != id || result.Magazine1 == null )
            //{
            //    msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found here");

            //}
            if (result == null )
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found here");

            }
            else if (result.Magazine1 == null )
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nothing Found here");

            }
            //else if (result.Magazine1.AutoID == magazineid && result.AutoID != id)
            //{

            //   msg = Request.CreateResponse(HttpStatusCode.NotFound);


            //}
            //else if (result.Magazine1.AutoID == magazineid && result = "")
            //{

            //    msg = Request.CreateResponse(HttpStatusCode.NotFound);


            //}
            else if(result.Magazine1.AutoID == magazineid)
            {
                msg = Request.CreateResponse(HttpStatusCode.OK, TheMagazineFactory.Create(result));
            }
            

                return msg;
        }
    }
}

