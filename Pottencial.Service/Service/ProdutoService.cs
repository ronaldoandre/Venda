using Pottencial.Domain.Entities;
using Pottencial.Domain.Interfaces.Repository;
using Pottencial.Domain.Interfaces.Service;

namespace Pottencial.Service.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IBaseRepository<ProdutoEntity> _repository;

        public ProdutoService(IBaseRepository<ProdutoEntity> repository)
        {
            _repository = repository;
        }
        public async Task<ProdutoEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ProdutoEntity> Insert(ProdutoEntity item)
        {
            return await _repository.Insert(item);
        }

        public async Task<ProdutoEntity> Update(ProdutoEntity item)
        {
            return await _repository.Update(item);
        }
    }
}