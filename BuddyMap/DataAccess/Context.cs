using BuddyMap.Models;
using Microsoft.EntityFrameworkCore;

namespace BuddyMap.DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerStudent>()
                .HasKey(ans => new { ans.AnswerId, ans.StudentId });

            modelBuilder.Entity<AnswerStudent>()
                .HasOne(ansstud => ansstud.Answer)
                .WithMany(ans => ans.AnswerStudents)
                .HasForeignKey(ansstud => ansstud.AnswerId);

            modelBuilder.Entity<AnswerStudent>()
               .HasOne(ansstud => ansstud.Student)
               .WithMany(stud => stud.AnswerStudents)
               .HasForeignKey(ansstud => ansstud.StudentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
