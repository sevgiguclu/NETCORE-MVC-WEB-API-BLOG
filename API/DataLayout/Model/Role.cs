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

        public int RoleCounter { get; set; }
        [Required]
        public bool RoleApproval { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RoleApprovalDate { get; set; }
    }
}
