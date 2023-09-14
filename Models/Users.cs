using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [Display(Name = "WhatsApp No")]
        public string WhatsappNo { get; set; }
        [Display(Name = "DOJ")]
        public DateTime DateOfJoining { get; set; }
        [Display(Name = "Emp Code")]
        public string EmpCode { get; set; }
        public int? Type { get; set; }
        public int? Division { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Designation")]
        public int? DesignationId { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean? Status { get; set; }
    }

    [Table("UsersView")]
    public class UsersView
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [Display(Name = "WhatsApp No")]
        public string WhatsappNo { get; set; }
        [Display(Name = "DOJ")]
        public DateTime DateOfJoining { get; set; }
        [Display(Name = "Emp Code")]
        public string EmpCode { get; set; }
        public int? Type { get; set; }
        public int? Division { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Designation")]
        public int? DesignationId { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean? Status { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string DivisionName { get; set; }
        public string TypeName { get; set; }
        public string StatusName { get; set; }
    }

}