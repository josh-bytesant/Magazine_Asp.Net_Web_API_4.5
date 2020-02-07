using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeService.Models
{
    public class MagazineArticleListModel
    {
        public string Url { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreatedDate { get; set; }

        public IEnumerable<ArticleListViewModel> Articles { get; set; }
    }
}