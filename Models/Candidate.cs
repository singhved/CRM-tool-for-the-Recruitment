using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Candidate")]
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "WhatsApp No.")]
        public string WhatsAppNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public int? Pin { get; set; }
        [Required]
        [Display(Name = "Primary Skill")]
        public int? PrimarySkillId { get; set; }

        [Display(Name = "Secondary Skill")]
        public int? SecondarySkilId { get; set; }
        [Required]
        public string Resume { get; set; }
        [Required]
        [Display(Name = "Exp in Yrs.")]
        public string Experiance { get; set; }
    }


    [Table("Education")]
    public class Education
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public int? DegreeId { get; set; }
        public string Specialization { get; set; }
        public int? UniversityId { get; set; }
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
    }


    [Table("WorkExperiance")]
    public class WorkExperiance
    {
        public int Id { get; set; }
        public int? CandidateId { get; set; }
        public string Organization { get; set; }
        public string Designation { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
    }


    [Table("CandidateView")]
    public class CandidateView
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        [Required]
        [Display(Name = "WhatsApp No.")]
        public string WhatsAppNo { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "DOB")]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public int? Pin { get; set; }
        [Required]
        [Display(Name = "Primary Skill")]
        public int? PrimarySkillId { get; set; }
        [Display(Name = "Secondary Skill")]
        public int? SecondarySkilId { get; set; }
        [Required]
        [Display(Name = "Resume")]
        public string Resume { get; set; }
        [Required]
        [Display(Name = "Exp in Yrs.")]
        public string Experiance { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string SkillCode { get; set; }
    }
}
