using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("PaymentTerms")]
    public class PaymentTerms
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Days { get; set; }
        public bool? Status { get; set; }
    }
}