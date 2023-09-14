using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    public class EducareContext : DbContext
    {
        public virtual DbSet<Department> Department { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Designation> Designations { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Subject> Subjects { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Level> Levels { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Users> Users { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.UsersView> UsersViews { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Affiliation> Affiliations { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Country> Countries { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.University> Universities { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.State> States { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.StateView> stateViews { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Skill> Skills { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Degree> Degrees { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.PaymentTerms> PaymentTerms { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Client> Client { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.ContactPerson> ContactPerson { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.ClientView> ClientView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.SkillView> SkillView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Education> Education { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.WorkExperiance> WorkExperiance { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Candidate> Candidates { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.CandidateView> CandidateView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.RequestsView> RequestsView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.Requests> Requests { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.RequestStatus> RequestStatus { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.RequestStatusView> RequestStatusView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.CandidateStatusView> CandidateStatusView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.CandidateStatus> CandidateStatus { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.ContactPersonView> ContactPersonView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.MappedCandidatesView> MappedCandidatesView { get; set; }
        public System.Data.Entity.DbSet<EduCare.Models.MappedCandidates> MappedCandidates { get; set; }
    }
}