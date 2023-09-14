using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Subject")]
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Boolean? Status { get; set; }

        [Display(Name="Code")]
        public string SubjectCode { get; set; }
    }
}