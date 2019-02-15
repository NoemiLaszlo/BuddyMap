using BuddyMap.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BuddyMap.ViewModels
{
    public class QuestionCreate
    {
        public Question Question { get; set; }
        public IEnumerable<QuestionGroup> QuestionGroups { get; set; }   
        public int SelectedQGId { get; set; }      
        
        public QuestionCreate()
        {
        }
    }
}
