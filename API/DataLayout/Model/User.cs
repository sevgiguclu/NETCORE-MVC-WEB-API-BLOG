using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Model
{
    public class User : IdentityUser
    {

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(11)]
        public string Phone { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Comment> Comments { get; set; }  // User'ın yorumları


        [Column(TypeName = "datetime2")]
        public DateTime ProfileUpdateDate { get; set; }



    }
}
