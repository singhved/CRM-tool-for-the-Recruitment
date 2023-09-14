using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public int? Pincode { get; set; }
        [Required]
        public string Website { get; set; }
        public Boolean? Status { get; set; }
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }
        [Display(Name="Country")]
        public int? BillingCountryId { get; set; }
        [Display(Name = "State")]
        public int? BillingStateId { get; set; }
        [Display(Name = "City")]
        public string BillingCity { get; set; }
        [Display(Name = "Pincode")]
        public int? BillingPincode { get; set; }
        [Display(Name = "Email")]
        public string BillingEmail { get; set; }
        [Display(Name = "Phone No.")]
        public string BillingPhoneNo { get; set; }
        [Display(Name = "GST No")]
        public string GSTNo { get; set; }
        [Display(Name = "Payment Terms")]
        public int? PaymentTermId { get; set; }
        [Display(Name = "Terms & Conditions")]
        public string TAndC { get; set; }
    }

    //Grid Table 


    [Table("ContactPerson")]
    public class ContactPerson
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string Name { get; set; }
        public int? DesignationId { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string WhatsAppNo { get; set; }
    }


    [Table("ClientView")]
    public class ClientView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name = "Pincode")]
        public int? Pincode { get; set; }
        [Required]
        public string Website { get; set; }
        public Boolean? Status { get; set; }
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }
        [Display(Name = "Country")]
        public int? BillingCountryId { get; set; }
        [Display(Name = "State")]
        public int? BillingStateId { get; set; }
        [Display(Name = "City")]
        public string BillingCity { get; set; }
        [Display(Name = "Pincode")]
        public int? BillingPincode { get; set; }
        [Display(Name = "Email")]
        public string BillingEmail { get; set; }
        [Display(Name = "Phone No.")]
        public string BillingPhoneNo { get; set; }
        public string GSTNo { get; set; }
        [Display(Name = "Payment Terms")]
        public int? PaymentTermId { get; set; }
        [Display(Name = "Terms & Conditions")]
        public string TAndC { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        [Display(Name="Billing Country")]
        public string BillingCountryName { get; set; }
        [Display(Name = "Billing State")]
        public string BillingStateName { get; set; }
        public string PaymentTerms { get; set; }
        public string Designation { get; set; }

    }

    //[Table("ContactPersonView")]
    //public class ContactPersonView
    //{
    //    public int Id { get; set; }
    //    public int? ClientId { get; set; }
    //    public string Name { get; set; }
    //    public int? DesignationId { get; set; }
    //    public int? DepartmentId { get; set; }
    //    public string Email { get; set; }
    //    public string ContactNo { get; set; }
    //    public string WhatsAppNo { get; set; }
    //    public string Designation { get; set; }
    //    public string Department { get; set; }
    //}
}