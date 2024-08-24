using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class Notification
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string title { get; set; }

        [Required]
        public string text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime createdDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime sentDate { get; set; }
    }
}
