using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Requests")]
    public class Requests
    {
        public int Id { get; set; }
        [Display(Name = "Client")]
        public int? ClientId { get; set; }
        [Required]
        [Display(Name = "Contact Person")]
        public int? ContactPersonId { get; set; }
        [Required]
        [Display(Name = "Skill Code")]
        public int? SkillId { get; set; }
        [Required]
        public int? Title { get; set; }
        [Required]
        public int? Vacancies { get; set; }
        [Required]
        public double? Experience { get; set; }
        [Required]
        public double? Salary { get; set; }
        [Required]
        public string Jd { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string JobSummary { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Cdate { get; set; }
        public string CTime { get; set; }
        public int? Recruiter { get; set; }
        public int? AllotedBy { get; set; }
        public DateTime? AllotmentDate { get; set; }
        public DateTime? AllotmentTime { get; set; }
        public int? Status { get; set; }

    }


    [Table("RequestsView")]
    public class RequestsView
    {
        public int Id { get; set; }
        [Display(Name = "Client")]
        public int? ClientId { get; set; }
        [Display(Name = "Contact Person")]
        public int? ContactPersonId { get; set; }
        [Display(Name = "Skill Code")]
        public int? SkillId { get; set; }
        public int? Title { get; set; }
        public int? Vacancies { get; set; }
        public double? Experience { get; set; }
        public double? Salary { get; set; }
        public string Jd { get; set; }
        public string Location { get; set; }
        public string JobSummary { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Cdate { get; set; }
        public string CTime { get; set; }
        public int? Recruiter { get; set; }
        public int? AllotedBy { get; set; }
        public DateTime? AllotmentDate { get; set; }
        public DateTime? AllotmentTime { get; set; }
        public string Client { get; set; }
        public string Branch { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
        public string CPEmail { get; set; }
        public string CPDesignation { get; set; }
        public string SkillCode { get; set; }
        public string Level { get; set; }
        public string Subject { get; set; }
        public string Affiliation { get; set; }
        public string TitleName { get; set; }
        public string SalesPerson { get; set; }
        public string RecruiterName { get; set; }
        public string RecruiterHead { get; set; }
        //public string Status { get; set; }

    }

    [Table("ContactPersonView")]
    public class ContactPersonView
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string ContactPerson { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string WhatsAppNo { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
    }


    
}
