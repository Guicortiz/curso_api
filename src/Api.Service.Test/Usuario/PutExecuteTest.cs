using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class PutExecuteTest : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "PutExecuteMethod")]
        public async Task PutExecuteMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(userDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuarioAlterado, result.Name);
            Assert.Equal(EmailUsuarioAlterado, result.Email);
            Assert.IsType<DateTime>(result.UpdateAt);
        }
    }
}
