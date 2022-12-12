using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Service
{
    public interface IVendaService
    {
        Task<VendaEntity> Insert(VendaEntity item);
        Task<VendaEntity> GetById(int id);
        Task<VendaEntity> Update(VendaEntity item);
    }
}