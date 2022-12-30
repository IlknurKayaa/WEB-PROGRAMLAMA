using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public string ArticleImage { get; set; }
        public DateTime ArticleCreateDate { get; set; }  
        public bool ArticleStatus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }

    }
}
