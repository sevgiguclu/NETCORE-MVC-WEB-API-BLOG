using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class AuthorCategory
    {
        public string AuthorRoleId { get; set; }
        public AuthorRole AuthorRole { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
