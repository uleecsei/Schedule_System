
namespace ScheduleService.Models
{
    public class TeacherOnLesson
    {
        public string Teacher_Id { get; set; }
        public string Lesson_Id { get; set; }
        public Teacher Teacher { get; set; }
        public Lesson Lesson { get; set; }
    }
}
