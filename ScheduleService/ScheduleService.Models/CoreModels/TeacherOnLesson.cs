
namespace ScheduleService.Models.CoreModels
{
    public class TeacherOnLesson
    {
        public int Teacher_Id { get; set; }
        public int Lesson_Id { get; set; }
        public Teacher Teacher { get; set; }
        public Lesson Lesson { get; set; }
    }
}
