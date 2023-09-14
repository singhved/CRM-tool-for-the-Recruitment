using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("MappedCandidates")]
    public class MappedCandidates
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? CandidateId { get; set; }
        public int? MappedBy { get; set; }
        public int? Status { get; set; }
        public DateTime? Cdate { get; set; }
        public int? ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? VideoLinkSent { get; set; }
        public string Video { get; set; }
        public DateTime? VidUploadDate { get; set; }
        public int? VidStatus { get; set; }
        public int? VidApprovalBy { get; set; }
        public int? VidSubmissions { get; set; }
        public int? SentToClient { get; set; }
        public int? ApprovedByClient { get; set; }
        public DateTime? ClientApprovalDate { get; set; }
    }

    [Table("MappedCandidatesView")]
    public class MappedCandidatesView
    {
        public int Id { get; set; }
        public int? RequestId { get; set; }
        public int? CandidateId { get; set; }
        public int? MappedBy { get; set; }
        public int? Status { get; set; }
        public DateTime? Cdate { get; set; }
        public int? ApprovalBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? VideoLinkSent { get; set; }
        public string Video { get; set; }
        public DateTime? VidUploadDate { get; set; }
        public int? VidStatus { get; set; }
        public int? VidApprovalBy { get; set; }
        public int? VidSubmissions { get; set; }
        public int? SentToClient { get; set; }
        public int? ApprovedByClient { get; set; }
        public DateTime? ClientApprovalDate { get; set; }
        public string TitleName { get; set; }
        public string Candidate { get; set; }
        public string SkillCode { get; set; }
        public string Client { get; set; }
    }
}