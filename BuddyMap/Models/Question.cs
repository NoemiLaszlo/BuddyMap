using BuddyMap.DataAccess;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuddyMap.Models
{
    public class Question 
    {
        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }
        public int NumOfAnswers { get; set; }
        public List<QQGConnection> QQGConnection { get; set; }

        public Question(int id, string questionText, int numOfAnswers, List<QQGConnection> qQGonnection)
        {
            Id = id;
            QuestionText = questionText;
            NumOfAnswers = numOfAnswers;
            QQGConnection = qQGonnection;
        }

        public Question()
        {
        }
        
    }
}
