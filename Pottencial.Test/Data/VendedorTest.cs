using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Data.Context;
using Pottencial.Data.Repository;
using Pottencial.Domain.Entities;
using Xunit;

namespace Pottencial.Test.Data
{
    public class VendedorTest : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public VendedorTest(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact]
        public async void Insert_VendedorServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendedorEntity> _repositorio = new BaseRepository<VendedorEntity>(context);
                VendedorEntity _entity = new VendedorEntity
                {
                    Nome = "teste",
                    Cpf = "12345678912",
                    Email = "teste@test.com",
                    Telefone = "2112345678"
                };

                var _registroCriado = await _repositorio.Insert(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal("12345678912", _registroCriado.Cpf);
                Assert.Equal("teste@test.com", _registroCriado.Email);
                Assert.Equal("2112345678", _registroCriado.Telefone);
            }
        }
        [Fact]
        public async void Update_VendedorServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendedorEntity> _repositorio = new BaseRepository<VendedorEntity>(context);

                VendedorEntity _entity2 = new VendedorEntity
                {
                    Nome = "teste",
                    Cpf = "12345678912",
                    Email = "teste@test.com",
                    Telefone = "2112345678"
                };
                VendedorEntity _entity = new VendedorEntity
                {
                    Id = 1,
                    Nome = "teste2",
                    Cpf = "98765432198",
                    Email = "teste2@test.com",
                    Telefone = "2187654321"
                };

                var _registroCriado = await _repositorio.Insert(_entity2);

                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal("12345678912", _registroCriado.Cpf);
                Assert.Equal("teste@test.com", _registroCriado.Email);
                Assert.Equal("2112345678", _registroCriado.Telefone);

                var _registroAtualizado = await _repositorio.Update(_entity);

                Assert.NotNull(_registroAtualizado);
                Assert.Equal("teste2", _registroAtualizado.Nome);
                Assert.Equal("98765432198", _registroAtualizado.Cpf);
                Assert.Equal("teste2@test.com", _registroAtualizado.Email);
                Assert.Equal("2187654321", _registroAtualizado.Telefone);
            }
        }

        [Fact]
        public async void GetById_VendedorServiceTest()
        {
            using (var context = _serviceProvider.GetService<PottencialContext>())
            {
                BaseRepository<VendedorEntity> _repositorio = new BaseRepository<VendedorEntity>(context);

                VendedorEntity _entity = new VendedorEntity
                {
                    Nome = "teste",
                    Cpf = "12345678912",
                    Email = "teste@test.com",
                    Telefone = "2112345678"
                };

                var _registroCriado = await _repositorio.Insert(_entity);
                var _registroGet = await _repositorio.GetById(_registroCriado.Id);

                Assert.NotNull(_registroCriado);
                Assert.Equal("teste", _registroCriado.Nome);
                Assert.Equal("12345678912", _registroCriado.Cpf);
                Assert.Equal("teste@test.com", _registroCriado.Email);
                Assert.Equal("2112345678", _registroCriado.Telefone);
                
                Assert.NotNull(_registroGet);
                Assert.Equal("teste", _registroGet.Nome);
                Assert.Equal("12345678912", _registroGet.Cpf);
                Assert.Equal("teste@test.com", _registroGet.Email);
                Assert.Equal("2112345678", _registroGet.Telefone);
            }
        }
    }
}