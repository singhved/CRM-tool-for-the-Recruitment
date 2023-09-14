using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("RequestStatus")]
    public class RequestStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Category { get; set; }
        public int? status { get; set; }
    }

    
    [Table("RequestStatusView")]
    public class RequestStatusView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Category { get; set; }
        public string status { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
    }
}