using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BuddyMap.Models
{
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; }
        public string QuestionGroupName { get; set; }
        public List<QQGConnection> QQGConnections { get; set; } = new List<QQGConnection>();

        [NotMapped]
        public List<Question> Questions { get => QQGConnections?.Select(qqg => qqg.Question).ToList(); }

        public QuestionGroup()
        {
        }

        public QuestionGroup(string questionGroupName)
        {
            QuestionGroupName = questionGroupName;
        }
    }
}
