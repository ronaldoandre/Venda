using Pottencial.Data.Context;
using Pottencial.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Domain.Entities;

namespace Pottencial.Test.Data
{
    public class ProdutoTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public ProdutoTest(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact]
        public async void Insert_ProdutoServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<ProdutoEntity> _repositorio = new BaseRepository<ProdutoEntity>(context);
                ProdutoEntity _entity = new ProdutoEntity
                {
                    Nome = "teste",
                    Valor = 12.34
                };

                var _registroCriado = await _repositorio.Insert(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal(12.34, _registroCriado.Valor);
            }
        }
        [Fact]
        public async void Update_ProdutoServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<ProdutoEntity> _repositorio = new BaseRepository<ProdutoEntity>(context);

                ProdutoEntity _entity2 = new ProdutoEntity
                {
                    Nome = "teste",
                    Valor = 12.34
                };
                ProdutoEntity _entity = new ProdutoEntity
                {
                    Id = 1,
                    Nome = "teste2",
                    Valor = 15.34
                };

                var _registroCriado = await _repositorio.Insert(_entity2);

                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal(12.34, _registroCriado.Valor);

                var _registroAtualizado = await _repositorio.Update(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal("teste2", _registroAtualizado.Nome);
                Assert.Equal(15.34, _registroAtualizado.Valor);
            }
        }

        [Fact]
        public async void GetById_ProdutoServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<ProdutoEntity> _repositorio = new BaseRepository<ProdutoEntity>(context);

                ProdutoEntity _entity = new ProdutoEntity
                {
                    Nome = "teste",
                    Valor = 12.34
                };

                var _registroCriado = await _repositorio.Insert(_entity);
                var _registroGet = await _repositorio.GetById(_registroCriado.Id);

                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal(12.34, _registroCriado.Valor);
                Assert.NotNull(_registroGet);
                Assert.Equal("teste", _registroGet.Nome);
                Assert.Equal(12.34, _registroGet.Valor);
            }
        }
    }
}