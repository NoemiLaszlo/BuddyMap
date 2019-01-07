using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class AnswerGroup
    {
        [Key]
        public int Id { get; set; }

        public Student Submitter { get; set; }
        public int SubmitterId { get; set; }

        public Campaign Campaign { get; set; }
        public int CampaignId { get; set; }

        public List<Answer> Answers { get; set; }

        public AnswerGroup()
        {
        }
    }
}