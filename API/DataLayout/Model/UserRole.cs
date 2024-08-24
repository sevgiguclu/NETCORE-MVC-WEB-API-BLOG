using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class userRole : User
    {
        public ICollection<Category> articleCategoryList {  get; set; } //kullanıcının takip etmek istediği kategori listesi

        public ICollection<Comment> comments { get; set; }

    }
}
