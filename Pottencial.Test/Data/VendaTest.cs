using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Data.Context;
using Pottencial.Data.Repository;
using Pottencial.Domain.Entities;
using Pottencial.Domain.Enuns;
using Xunit;

namespace Pottencial.Test.Data
{
    public class VendaTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public VendaTest(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact]
        public async void Insert_VendaServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendaEntity> _repositorio = new BaseRepository<VendaEntity>(context);
                BaseRepository<ProdutoEntity> _repositorioP = new BaseRepository<ProdutoEntity>(context);
                BaseRepository<VendedorEntity> _repositorioV = new BaseRepository<VendedorEntity>(context);
                VendedorEntity _entity4 = new VendedorEntity
                {
                    Nome = "teste",
                    Cpf = "12345678912",
                    Email = "teste@test.com",
                    Telefone = "2112345678"
                };

                await _repositorioV.Insert(_entity4);
                ProdutoEntity _entity3 = new ProdutoEntity
                {
                    Nome = "teste",
                    Valor = 12.34
                };
                ProdutoEntity _entity2 = new ProdutoEntity
                {
                    Nome = "teste2",
                    Valor = 43.21
                };
                await _repositorioP.Insert(_entity3);
                await _repositorioP.Insert(_entity2);
                var prod1 = await _repositorioP.GetById(1);
                var prod2 = await _repositorioP.GetById(2);

                VendaEntity _entity = new VendaEntity
                {
                    Status = StatusVendaEnum.AguardandoPagamento,
                    DataVenda = new DateTime(2022,01,30,10,40,59),
                    Produtos = {prod1,prod2},
                    VendedorId = 1

                };

                var _registroCriado = await _repositorio.Insert(_entity);
                Assert.NotNull(_registroCriado);
                //Assert.Equal(12.34, _registroCriado.Produtos.Where(x => x.Nome == "teste").FirstOrDefault().Valor);
                //Assert.Equal(43.21, _registroCriado.Produtos.Where(x => x.Nome == "teste2").FirstOrDefault().Valor);
                Assert.Equal(new DateTime(2022,01,30,10,40,59), _registroCriado.DataVenda);
                Assert.Equal(StatusVendaEnum.AguardandoPagamento, _registroCriado.Status);
            }
        }
        [Fact]
        public async void Update_ProdutoServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendaEntity> _repositorio = new BaseRepository<VendaEntity>(context);

                VendaEntity _entity2 = new VendaEntity
                {
                    Status = StatusVendaEnum.AguardandoPagamento,
                    DataVenda = new DateTime(2022,01,30,10,40,59),
                    Produtos = {new ProdutoEntity{Nome = "teste", Valor = 12.34},
                                new ProdutoEntity{Nome = "teste2", Valor = 43.21}}
                };
                VendaEntity _entity = new VendaEntity
                {
                    Status = StatusVendaEnum.PagamentoAprovado,
                    DataVenda = new DateTime(2022,01,30,10,40,59),
                    Produtos = {new ProdutoEntity{Nome = "teste", Valor = 12.34},
                                new ProdutoEntity{Nome = "teste2", Valor = 43.21}}
                };

                var _registroCriado = await _repositorio.Insert(_entity2);

                Assert.NotNull(_registroCriado);
                Assert.Equal(12.34, _registroCriado.Produtos.Where(x => x.Nome == "teste").FirstOrDefault().Valor);
                Assert.Equal(43.21, _registroCriado.Produtos.Where(x => x.Nome == "teste2").FirstOrDefault().Valor);
                Assert.Equal(new DateTime(2022,01,30,10,40,59), _registroCriado.DataVenda);
                Assert.Equal(StatusVendaEnum.AguardandoPagamento, _registroCriado.Status);

                var _registroAtualizado = await _repositorio.Update(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal(12.34, _registroAtualizado.Produtos.Where(x => x.Nome == "teste").FirstOrDefault().Valor);
                Assert.Equal(43.21, _registroAtualizado.Produtos.Where(x => x.Nome == "teste2").FirstOrDefault().Valor);
                Assert.Equal(new DateTime(2022,01,30,10,40,59), _registroAtualizado.DataVenda);
                Assert.Equal(StatusVendaEnum.PagamentoAprovado, _registroAtualizado.Status);
            }
        }

        [Fact]
        public async void GetById_ProdutoServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendaEntity> _repositorio = new BaseRepository<VendaEntity>(context);

                VendaEntity _entity = new VendaEntity
                {
                    Status = StatusVendaEnum.AguardandoPagamento,
                    DataVenda = new DateTime(2022,01,30,10,40,59),
                    Produtos = {new ProdutoEntity{Nome = "teste", Valor = 12.34},
                                new ProdutoEntity{Nome = "teste2", Valor = 43.21}}
                };

                var _registroCriado = await _repositorio.Insert(_entity);
                var _registroGet = await _repositorio.GetById(_registroCriado.Id);

                Assert.NotNull(_registroCriado);
                Assert.Equal(12.34, _registroCriado.Produtos.Where(x => x.Nome == "teste").FirstOrDefault().Valor);
                Assert.Equal(43.21, _registroCriado.Produtos.Where(x => x.Nome == "teste2").FirstOrDefault().Valor);
                Assert.Equal(new DateTime(2022,01,30,10,40,59), _registroCriado.DataVenda);
                Assert.Equal(StatusVendaEnum.AguardandoPagamento, _registroCriado.Status);

                Assert.NotNull(_registroGet);
                Assert.Equal(12.34, _registroGet.Produtos.Where(x => x.Nome == "teste").FirstOrDefault().Valor);
                Assert.Equal(43.21, _registroGet.Produtos.Where(x => x.Nome == "teste2").FirstOrDefault().Valor);
                Assert.Equal(new DateTime(2022,01,30,10,40,59), _registroGet.DataVenda);
                Assert.Equal(StatusVendaEnum.AguardandoPagamento, _registroGet.Status);
            }
        }
    }
}