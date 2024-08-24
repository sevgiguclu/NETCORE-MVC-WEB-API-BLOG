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
    public class Role : IdentityRole
    {

        public int roleCounter { get; set; }//rolün kullanıcı sayısını tutar

        public ICollection<User> Users { get; set; }

        [Required]
        public Boolean roleApproval { get; set; } // rolün onayının durumunu tutar

        [Column(TypeName = "datetime2")]
        public DateTime roleApprovalDate { get; set; }
    }
}
