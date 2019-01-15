using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuddyMap.Models
{
    public class QQGConnection
    {
        public int QuestionId { get; set; }
        public int QuestionGroupId { get; set; }
        public Question Question { get; set; }
        public QuestionGroup QuestionGroup { get; set; }
    }
}
