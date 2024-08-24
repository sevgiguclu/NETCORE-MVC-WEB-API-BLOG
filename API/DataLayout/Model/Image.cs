using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Image
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Url { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
