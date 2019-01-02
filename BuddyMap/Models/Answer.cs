using System.Collections.Generic;

namespace BuddyMap.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int CampaignId { get; set; }
        public int QuestionId { get; set; }
        public int SubmitterStudentId { get; set; }

        public List<AnswerStudent> AnswerStudents { get; set; }
    }
}