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
        private ILessonInformationRepository _lessonInformationRepository;
        private IGroupRepository _groupRepository;
        private ICurrentWeekNumberRepository _currentWeekNumberRepository;
        private ILessonInHistoryRepository _lessonInHistoryRepository;
        private ILessonFileRepository _lessonFileRepository;
        private readonly ScheduleSystemContext _context;

        public ICurrentWeekNumberRepository CurrentWeekNumberRepository
        {
            get
            {
                return _currentWeekNumberRepository = _currentWeekNumberRepository ?? new CurrentWeekNumberRepository(_context);
            }
        }

        public ILessonFileRepository LessonFileRepository
        {
            get
            {
                return _lessonFileRepository = _lessonFileRepository ?? new LessonFileRepository(_context);
            }
        }

        public ILessonRepository LessonRepository
        {
            get
            {
                return _lessonRepository = _lessonRepository ?? new LessonRepository(_context);
            }
        }

        public IGroupRepository GroupRepository
        {
            get
            {
                return _groupRepository = _groupRepository ?? new GroupRepository(_context);
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

        public ILessonInformationRepository LessonInformationRepository
        {
            get
            {
                return _lessonInformationRepository = _lessonInformationRepository ?? new LessonInformationRepository(_context);
            }
        }

        public ILessonInHistoryRepository lessonInHistoryRepository
        {
            get
            {
                return _lessonInHistoryRepository = _lessonInHistoryRepository ?? new LessonInHistoryRepository(_context);
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