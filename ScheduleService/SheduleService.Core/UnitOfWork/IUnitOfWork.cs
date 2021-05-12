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
        ITeacherOnLessonRepository TeacherOnLessonRepository { get; }

        Task<bool> SaveChanges();
    }
}
