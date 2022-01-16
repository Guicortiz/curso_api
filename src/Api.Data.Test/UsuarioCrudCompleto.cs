using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvide;

        public UsuarioCrudCompleto(DbTest dbTest)
        {
            _serviceProvide = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUID_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                var _registroExiste = await _repository.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repository.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_registroAtualizado.Email, _registroSelecionado.Email);
                Assert.Equal(_registroAtualizado.Name, _registroSelecionado.Name);

                var _todosRegistros = await _repository.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                var _removeu = await _repository.DeleteAsync(_registroAtualizado.Id);
                Assert.True(_removeu);

                var _usuarioPadrao = await _repository.FindByLogin("guicortiz@gmail.com");
                Assert.NotNull(_usuarioPadrao);
                Assert.Equal("guicortiz@gmail.com", _usuarioPadrao.Email);
                Assert.Equal("Administrador", _usuarioPadrao.Name);
            }
        }
    }
}
