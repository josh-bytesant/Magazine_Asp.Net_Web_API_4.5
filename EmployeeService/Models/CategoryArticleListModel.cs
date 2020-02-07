using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService.Models
{
    public class CategoryArticleListModel
    {
        public string Url { get; set; }
        public string ArticleCategory { get; set; }

        public IEnumerable<ArticleListViewModel> Articles { get; set; }
    }
}