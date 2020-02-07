using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService.Models
{
    public class ArticleListViewModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public string ArticleCategory { get; set; }

        public string Thumbnail { get; set; }

        public string Video { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ExpiryDate { get; set; }



    }
}