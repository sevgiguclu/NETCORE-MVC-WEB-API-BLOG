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
        public string name { get; set; }

        public ICollection<AuthorRole> authors { get; set; }

    }
}
