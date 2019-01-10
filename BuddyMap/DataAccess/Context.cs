using BuddyMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyMap.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            //var x = 1;
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<StudentGroup> StudentGroup { get; set; }
        public DbSet<AnswerGroup> AnswerGroup { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<AnswerElement> AnswerElement { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionGroup> QuestionGroup { get; set; }
        public DbSet<Campaign> Campaign { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AnswerGroup>()
            //    .HasMany(elem => elem.Answers)
            //    .WithOne();
            //modelBuilder.Entity<AnswerGroup>()
            //    .HasOne(elem => elem.Campaign)
            //    .WithMany();
            //modelBuilder.Entity<AnswerGroup>()
            //    .HasOne(elem => elem.Submitter)
            //    .WithOne();

            //modelBuilder.Entity<Answer>()
            //    .HasOne<Question>(elem => elem.Question)
            //    .WithOne();

            //modelBuilder.Entity<XXAnswerStudent>()
            //    .HasKey(ans => new { ans.AnswerId, ans.StudentId });

            //modelBuilder.Entity<XXAnswerStudent>()
            //    .HasOne(ansstud => ansstud.Answer)
            //    .WithMany(ans => ans.AnswerStudents)
            //    .HasForeignKey(ansstud => ansstud.AnswerId);

            //modelBuilder.Entity<XXAnswerStudent>()
            //   .HasOne(ansstud => ansstud.Student)
            //   .WithMany(stud => stud.AnswerStudents)
            //   .HasForeignKey(ansstud => ansstud.StudentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
