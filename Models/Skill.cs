using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduCare.Models
{
    [Table("Skill")]
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        public int? SubjectId { get; set; }
        [Required]
        public int? LevelId { get; set; }
        [Required]
        public int? AffiliationId { get; set; }
        public bool? Status { get; set; }
        public string SkillCode { get; set; }
    }
    [Table("SkillView")]
    public class SkillView
    {
        public int Id { get; set; }
        [Required]
        public bool? Status { get; set; }
        public string Subject { get; set; }
        public string Level { get; set; }
        public string Affiliation { get; set; }
        public string SkillCode { get; set; }
    }
}