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
        public string firstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }

        [MaxLength(11)]
        public string phone {  get; set; }

        public Notification notification { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime profileUpdateDate { get; set; }



    }
}
