namespace BuddyMap.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int NumOfAnswers { get; set; }
        public int QuestionGroupId { get; set; }
    }
}
