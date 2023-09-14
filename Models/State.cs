using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("State")]
    public class State
    {
        public int Id { get; set; }
        [Display(Name="Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name="State")]
        public string Name { get; set; }
        public bool? Status { get; set; }
    }

    [Table("StateView")]
    public class StateView
    {
        public int Id { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name = "State")]
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string CountryName { get; set; }
    }
}