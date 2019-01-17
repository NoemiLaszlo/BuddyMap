using BuddyMap.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BuddyMap.ViewModels
{
    public class QuestionCreate
    {
        public Question Questions { get; set; }
        public List<QuestionGroup> QuestionGroups { get; set; }        

        public int SelectedQGId { get; set; }

        public IEnumerable<SelectListItem> QGItems
        {
            get { return new SelectList(QuestionGroups, "Id", "QuestionGroupName"); }
        }
    }
}
