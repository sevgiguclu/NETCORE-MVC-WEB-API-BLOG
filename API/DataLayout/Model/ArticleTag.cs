using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class ArticleTag
    {
        public int articleID { get; set; }
        public Article article { get; set; }

        public int tagID { get; set; }
        public Tag tag { get; set; }
    }
}
