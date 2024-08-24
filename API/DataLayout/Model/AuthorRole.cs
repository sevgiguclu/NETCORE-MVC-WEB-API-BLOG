using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class AuthorRole:User
    {
        public ICollection<AuthorCategory> AuthorCategories { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
