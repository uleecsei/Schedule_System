using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleService.Models.CoreModels;

namespace SheduleService.Core.DataAccess
{
    public class ScheduleSystemContext : IdentityDbContext<User>
    {
        public ScheduleSystemContext(DbContextOptions<ScheduleSystemContext> options) : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<LessonInHistory> LessonInHistories { get; set; }
        public DbSet<LessonInformation> LessonInformations { get; set; }
        public DbSet<LessonFile> LessonFiles { get; set; }
        public DbSet<TeacherOnLesson> TeacherOnLessons { get; set; }
        public DbSet<CurrentWeekNumber> CurrentWeekNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>(ls =>
            {
                ls.HasKey(x => x.lesson_id);

                ls.HasOne(x => x.Group)
                .WithMany(x => x.Lesson)
                .HasForeignKey(x => x.group_id);
            });

            modelBuilder.Entity<CurrentWeekNumber>(c =>
            {
                c.HasNoKey();
            });

            modelBuilder.Entity<LessonInHistory>(ls =>
            {
                ls.HasKey(x => x.LessonInHistoryId);

                ls.HasOne(x => x.Lesson)
                .WithMany(x => x.LessonInHistories)
                .HasForeignKey(x => x.lesson_id);
            });

            modelBuilder.Entity<Teacher>(ls =>
            {
                ls.HasKey(x => x.teacher_id);
            });

            modelBuilder.Entity<Group>(gr =>
            {
                gr.HasKey(x => x.group_id);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(x => x.Group)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.group_id)
                .IsRequired(false);
            });

            modelBuilder.Entity<LessonInformation>(li =>
            {
                li.HasKey(x => x.LessonInformationId);

                li.HasOne(x => x.LessonInHistory)
                .WithOne(x => x.LessonInformation);
            });

            modelBuilder.Entity<LessonFile>(lf =>
            {
                lf.HasKey(x => x.FileId);

                lf.HasOne(x => x.LessonInHistory)
                .WithMany(x => x.LessonFile)
                .HasForeignKey(x => x.LessonInHistoryId);
            });

            modelBuilder.Entity<TeacherOnLesson>(tls =>
            {
                tls.HasKey(key => new { key.Lesson_Id, key.Teacher_Id });

                tls.HasOne(tls => tls.Lesson)
                .WithMany(ls => ls.Teachers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(tls => tls.Lesson_Id);

                tls.HasOne(tls => tls.Teacher)
                .WithMany(ls => ls.Lessons)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(tls => tls.Teacher_Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
