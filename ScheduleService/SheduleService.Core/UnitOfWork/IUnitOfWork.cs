using SheduleService.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SheduleService.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ILessonRepository LessonRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        IGroupRepository GroupRepository { get; }
        ITeacherOnLessonRepository TeacherOnLessonRepository { get; }
        ILessonInformationRepository LessonInformationRepository { get; }
        ICurrentWeekNumberRepository CurrentWeekNumberRepository { get; }
        ILessonInHistoryRepository lessonInHistoryRepository { get; }
        ILessonFileRepository LessonFileRepository { get; }
        Task<bool> SaveChanges();
    }
}
