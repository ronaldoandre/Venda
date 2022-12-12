using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pottencial.Domain.Interfaces.Repository;
using Pottencial.Domain.Entities;
using Pottencial.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Pottencial.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PottencialContext _context;
        protected readonly DbSet<T> _dataSet;
        public BaseRepository(PottencialContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            var result = await _dataSet.ToListAsync();

            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await _dataSet
                .FirstOrDefaultAsync(u => u.Id.Equals(id));

            return result;
        }

        public async Task<T> Insert(T item)
        {
            await _dataSet.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<T> Update(T item)
        {

            var result = await this.GetById(item.Id);

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}