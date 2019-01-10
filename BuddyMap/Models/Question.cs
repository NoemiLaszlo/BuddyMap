using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }
        public int NumOfAnswers { get; set; }
        //public int QuestionGroupId { get; set; }

        public Question(int id, string questionText, int numOfAnswers/*, int questionGroupId*/)
        {
            Id = id;
            QuestionText = questionText;
            NumOfAnswers = numOfAnswers;
            //QuestionGroupId = questionGroupId;
        }

        public Question()
        {
        }
    }
}
