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
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SentDate { get; set; }

        // Foreign key for User
        public string UserId { get; set; }
        public User User { get; set; }  // Navigation property to User

    }
}
