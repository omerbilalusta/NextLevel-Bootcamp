using Microsoft.EntityFrameworkCore;
using NextLevel_Bootcamp_FinalWork.Models.Models;

namespace NextLevel_Bootcamp_FinalWork.Models.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz_Question>()
                .HasOne(x => x.Question)
                .WithMany(x => x.Quiz_Questions)
                .HasForeignKey(x => x.QuestionID);

            modelBuilder.Entity<Quiz_Question>()
                .HasOne(x => x.Quiz)
                .WithMany(x => x.Quiz_Questions)
                .HasForeignKey(x => x.QuizID);

            modelBuilder.Entity<Answer>()
                .HasOne(x => x.Question)
                .WithMany(d => d.Answers);

            modelBuilder.Entity<Scoreboard>()
                .HasOne(x => x.User)
                .WithMany(x => x.Scoreboards)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Scoreboard>()
                .HasOne(x => x.Quiz)
                .WithMany(x => x.Scoreboards)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(x => x.UserType)
                .WithMany(x => x.Users);

        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz_Question> Quiz_Questions { get; set; }
        public DbSet<Scoreboard> Scoreboards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
