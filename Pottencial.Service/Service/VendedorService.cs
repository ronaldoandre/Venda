using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repository;
using Pottencial.Domain.Interfaces.Service;

namespace Pottencial.Service.Service
{
    public class VendedorService : IVendedorService
    {
        private readonly IBaseRepository<VendedorEntity> _repository;
        public VendedorService(IBaseRepository<VendedorEntity> repository)
        {
            _repository = repository;
        }
        public async Task<VendedorEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<VendedorEntity> Insert(VendedorEntity item)
        {
            return await _repository.Insert(item);
        }

        public async Task<VendedorEntity> Update(VendedorEntity item)
        {
            return await _repository.Update(item);
        }
    }
}