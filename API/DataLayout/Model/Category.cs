using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Category
    {
        [Key]
        public int ID {  get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        // Category'nin birden fazla Article ile ilişkili olmasını sağlar
        public ICollection<Article> Articles { get; set; }

        public ICollection<AuthorCategory> AuthorCategories { get; set; }  // Many-to-Many ilişki için

        public ICollection<userRole> Users { get; set; }

    }
}
