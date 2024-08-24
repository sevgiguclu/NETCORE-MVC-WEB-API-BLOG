using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class AuthorRole:User
    {
        public ICollection<Category> categories {  get; set; }

        public ICollection<Article> articles { get; set; }



    }
}
