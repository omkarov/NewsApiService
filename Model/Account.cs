using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Model
{
    public class Account
    {

        [Key]
        public string EmpId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        //public Role Role { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Nationality { get; set; }

        //for giving star
        [Required]
        
        [DefaultValue(0)]
        public int NewsCount { get; set; }  =  0;

        public bool UserIsApprovedByAdmin { get; set; }  =  false;
    }
}



