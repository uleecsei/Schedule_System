﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Add(T value);
        void Remove(T value);
    }
}