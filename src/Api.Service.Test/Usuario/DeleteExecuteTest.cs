using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class DeleteExecuteTest : UsuarioTestes
    {
        private IUserService _service;

        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "DeleteExecuteMethod")]
        public async Task DeleteExecuteMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdUsuario);
            Assert.True(result);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            result = await _service.Delete(IdUsuario);
            Assert.False(result);
            Assert.NotNull(result);
        }
    }
}
