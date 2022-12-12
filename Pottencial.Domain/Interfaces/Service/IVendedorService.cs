using System.Threading.Tasks;
using Pottencial.Domain.Entities;

namespace Pottencial.Domain.Interfaces.Service
{
    public interface IVendedorService
    {
        Task<VendedorEntity> Insert(VendedorEntity item);
        Task<VendedorEntity> GetById(int id);
        Task<VendedorEntity> Update(VendedorEntity item);
    }
}