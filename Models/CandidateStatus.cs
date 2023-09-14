using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("CandidateStatus")]
    public class CandidateStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Category { get; set; }
        public int? status { get; set; }
    }
    
    [Table("CandidateStatusView")]
    public class CandidateStatusView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }
        public int? status { get; set; }
        public string CategoryName { get; set; }
        public string StatusName { get; set; }
    }
}