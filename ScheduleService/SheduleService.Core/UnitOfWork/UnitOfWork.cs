using SheduleService.Core.DataAccess;
using SheduleService.Core.Repository;
using SheduleService.Core.Repository.Interfaces;
using SheduleService.Core.UnitOfWork;
using System.Threading.Tasks;

namespace SheduleService.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private ILessonRepository _lessonRepository;
        private ITeacherRepository _teacherRepository;
        private ITeacherOnLessonRepository _teacherOnLessonRepository;
        private readonly ScheduleSystemContext _context;

        public ILessonRepository LessonRepository 
        {
            get
            {
                return _lessonRepository = _lessonRepository ?? new LessonRepository(_context);
            }
        }
        public ITeacherRepository TeacherRepository
        {
            get
            {
                return _teacherRepository = _teacherRepository ?? new TeacherRepository(_context);
            }
        }
        public ITeacherOnLessonRepository TeacherOnLessonRepository
        {
            get
            {
                return _teacherOnLessonRepository = _teacherOnLessonRepository ?? new TeacherOnLessonRepository(_context);
            }
        }


        public UnitOfWork(ScheduleSystemContext context)
        {
            _context = context;
        }

     
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}