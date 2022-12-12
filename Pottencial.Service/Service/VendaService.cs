using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repository;
using Pottencial.Domain.Interfaces.Service;

namespace Pottencial.Service.Service
{
    public class VendaService : IVendaService
    {
        private readonly IBaseRepository<VendaEntity> _repository;

        public VendaService(IBaseRepository<VendaEntity> repository)
        {
            _repository = repository;   
        }
        public async Task<VendaEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<VendaEntity> Insert(VendaEntity item)
        {
            return await _repository.Insert(item);
        }

        public async Task<VendaEntity> Update(VendaEntity item)
        {
            return await _repository.Update(item);
        }
    }
}