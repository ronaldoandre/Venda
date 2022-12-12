using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<ProdutoEntity> Insert(ProdutoEntity item);
        Task<ProdutoEntity> GetById(int id);
        Task<ProdutoEntity> Update(ProdutoEntity item);
    }
}