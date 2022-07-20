using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Model
{
    public class News
    {
        [Key]
        public string NewsId { get; set; }

        public string NewsAuthor { get; set; }
        [ForeignKey("NewsAuthor")]
        public Account acc { get; set; }

        [Required]
        public string NewsCategory { get; set; }

        //[ForeignKey("User")]
        public string ApprovedBy { get; set; }
        [ForeignKey("ApprovedBy")]
        public Account acc1 { get; set; }

        [Required]
        public string NewsLocation { get; set; }


        [Required]
        public string NewsTitle { get; set; }
        
        [MaxLength(500)]
        public string NewsMatter { get; set; }

        [Required]
        public DateTime NewsTime { get; set; }

        
    }
}
