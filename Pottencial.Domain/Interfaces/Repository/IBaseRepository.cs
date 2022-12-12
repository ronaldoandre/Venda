using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> Update(T item);
    }
}