using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("sendEmail")]
    public class sendEmail
    {
        public int Id { get; set; }
        [Required]
        public string Tomail { get; set; }
        [Required]
        public string CCmail { get; set; }
        [Required]
        public string Attachment { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}