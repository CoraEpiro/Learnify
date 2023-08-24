using AppDomain.Entities.ContentRelated;
using AppDomain.Entities.NotificationRelated;
using AppDomain.Entities.TagBaseRelated;
using AppDomain.Entities.UserRelated;
using AppDomain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace Infrastructure.Persistence;

public class LearnifyDbContext : DbContext
{
    public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options)
        : base(options)
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasQueryFilter(c => c.isDeleted == false);
        modelBuilder.Entity<ResourceFlag>().HasQueryFilter(c => c.isDeleted == false);
        modelBuilder.Entity<ArticleFlag>().HasQueryFilter(c => c.isDeleted == false);

        modelBuilder.Entity<Category>().Property(b => b.isDeleted).HasDefaultValue(false);

        modelBuilder.Entity<ResourceFlag>().Property(b => b.isDeleted).HasDefaultValue(false);

        modelBuilder.Entity<ArticleFlag>().Property(b => b.isDeleted).HasDefaultValue(false);
    }

    /*    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply value converters for properties using JSONB format

            modelBuilder.Entity<User>()
                .Property(u => u.PersonalInfo)
                .HasConversion(
                    pi => JsonConvert.SerializeObject(pi),
                    json => JsonConvert.DeserializeObject<PersonalInfo>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.CategoryFollowedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.Brand)
                .HasConversion(
                    brand => JsonConvert.SerializeObject(brand),
                    json => JsonConvert.DeserializeObject<Brand>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.Settings)
                .HasConversion(
                    settings => JsonConvert.SerializeObject(settings),
                    json => JsonConvert.DeserializeObject<Settings>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ConnectedAccountList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<ConnectedAccount>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.BadgeList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<Badge>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.Grade)
                .HasConversion(
                    grades => JsonConvert.SerializeObject(grades),
                    json => JsonConvert.DeserializeObject<Grade>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.NotificationList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<Notification>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ArticleViewedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ArticleSavedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ArticleVoteList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<VoteState>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.QuestionViewedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.QuestionSavedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.QuestionVoteList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<VoteState>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.WatchedQuestionList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ResourceSavedList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ResourceVoteList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<VoteState>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.FinishedCourses)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.ProgressList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<Progress>>(json));

            modelBuilder.Entity<User>()
                .Property(u => u.CommentVoteList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<VoteState>>(json));

            modelBuilder.Entity<PersonalInfo>()
                .HasNoKey()
                .Property(u => u.PinnedArticles)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            modelBuilder.Entity<PersonalInfo>()
                .HasNoKey()
                .Property(u => u.PinnedRepositories)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<PinnedRepository>>(json));

            modelBuilder.Entity<Progress>()
                .HasNoKey()
                .Property(u => u.TopicProgressList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<TopicProgress>>(json));

            modelBuilder.Entity<TopicProgress>()
                .HasNoKey()
                .Property(u => u.LessonList)
                .HasConversion(
                    list => JsonConvert.SerializeObject(list),
                    json => JsonConvert.DeserializeObject<IEnumerable<string>>(json));

            // Apply similar value converters for other properties...
        }
    */
}
