using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        MagazineFactory _magazineFactory;
        CategoryFactory _categoryFactory;
        public NewsEntities entities = new NewsEntities();

        protected MagazineFactory TheMagazineFactory
        {
            get
            {
                if (_magazineFactory == null)
                {
                    _magazineFactory = new MagazineFactory(this.Request);
                }
                return _magazineFactory;
            }
        }

        protected CategoryFactory TheCategoryFactory
        {
            get
            {
                if (_categoryFactory == null)
                {
                    _categoryFactory = new CategoryFactory(this.Request);
                }
                return _categoryFactory;
            }
        }
    }
}
