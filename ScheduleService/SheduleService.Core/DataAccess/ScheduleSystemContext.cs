using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleService.CoreModels;
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

        public DbSet<TeacherOnLesson> TeacherOnLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>(ls =>
            {
                ls.HasKey(x => x.lesson_id);
            });

            modelBuilder.Entity<Teacher>(ls =>
            {
                ls.HasKey(x => x.teacher_id);
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
