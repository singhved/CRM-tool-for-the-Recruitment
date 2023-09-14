using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("University")]
    public class University
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? Status { get; set; }
    }
}