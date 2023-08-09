using AppDomain.Entities.ContentRelated;
using AppDomain.Entities.NotificationRelated;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class LearnifyDbContext : DbContext
{
	public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options) : base(options)
	{
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<PendingUser> PendingUsers { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<QuestionNotification> QuestionNotifications { get; set; }
    public DbSet<ArticleNotification> ArticleNotifications { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }
    public DbSet<CommentNotification> CommentNotifications { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    //public DbSet<Comment> Comments { get; set; }
    public DbSet<ArticleFlag> ArticleFlags { get; set; }
    public DbSet<ResourceFlag> ResourceFlags { get; set; }
    //public DbSet<FailAttemp> FailAttemps { get; set; }
    public DbSet<EmailVerification> EmailVerifications { get; set; }
}