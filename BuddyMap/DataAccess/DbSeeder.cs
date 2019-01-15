using BuddyMap.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuddyMap.DataAccess
{
    public static class DbSeeder
    {
        public static void SeedDb(Context context)
        {
            SeedStudents(context);
            SeedQuestions(context);
            SeedQuestionGroups(context);
            SeedAnswerGroups(context);
        }

        //private static void SeedUser(UserManager<IdentityUser> userManager)
        //{
        //    IdentityUser identityUser = new IdentityUser
        //    {
        //        UserName = "noe@email.com",
        //        Email = "noe@email.com"
        //    };

        //    userManager.CreateAsync(identityUser, "P@ssword123!").Wait();
        //}

        private static void SeedStudents(Context context)
        {
            context.Database.EnsureCreated();
            context.Student.Add(new Student() { Name = "Noe", Email = "noe@email.com" });
            context.Student.Add(new Student() { Name = "Atti", Email = "atti@email.com" });
            context.Student.Add(new Student() { Name = "Tomi", Email = "tomi@email.com" });
            context.SaveChanges();
        }

        private static void SeedAnswerGroups(Context context)
        {
            context.Database.EnsureCreated();
            context.AnswerGroup.Add(new AnswerGroup() { SubmitterId = 1, CampaignId = 1 });
            context.AnswerGroup.Add(new AnswerGroup() { SubmitterId = 2, CampaignId = 2 });
            context.AnswerGroup.Add(new AnswerGroup() { SubmitterId = 3, CampaignId = 3 });
            context.SaveChanges();
        }

        private static void SeedQuestions(Context context)
        {
            context.Database.EnsureCreated();
            context.Question.Add(new Question() { QuestionText = "Az első kérdés?", NumOfAnswers = 1, QQGConnection = { } });
            context.Question.Add(new Question() { QuestionText = "A második kérdés?", NumOfAnswers = 2, QQGConnection = { } });
            context.Question.Add(new Question() { QuestionText = "A harmadik kérdés?", NumOfAnswers = 3, QQGConnection = { } });
            context.SaveChanges();
        }

        private static void SeedQuestionGroups(Context context)
        {

            context.Database.EnsureCreated();
            var q = context.Question.Where(question => question.Id == 2).First();            
            context.QuestionGroup.Add(new QuestionGroup() { QuestionGroupName = "Proba1",
                                                            Questions = new List<Question>() { q }
                                                           });
            var k = context.Question.Where(question => question.Id == 3).First();
            context.QuestionGroup.Add(new QuestionGroup() { QuestionGroupName = "Proba2",
                                                            Questions = new List<Question>() { k }
                                                           });

            context.SaveChanges();
        }
    }
}
