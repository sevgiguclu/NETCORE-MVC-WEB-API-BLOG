using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class userRole : User
    {
        public ICollection<Category> ArticleCategoryList { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
