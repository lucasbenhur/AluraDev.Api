using AluraDev.Domain.Interfaces;
using AluraDev.Domain.Models;
using AluraDev.Services;
using Moq;
using NUnit.Framework;

namespace AluraDev.Tests.UnitTests.Services
{
    [TestFixture]
    public class ProjetoServiceTests
    {
        private Mock<IProjetoRepository> _mockProjetoRepository;

        [SetUp]
        public void SetUp()
        {
            _mockProjetoRepository = new Mock<IProjetoRepository>();
        }

        private ProjetoService GetProjetoService()
        {
            return new ProjetoService(
                _mockProjetoRepository.Object);
        }

        private Projeto GetValidProjeto()
        {
            return new Projeto
            {
                Nome = "Projeto teste",
                Descricao = "Este é um projeto teste",
                Codigo = "Código Teste",
                Cor = "#123456",
                Linguagem = "csharp",
                Usuario = new Usuario
                {
                    UserName = "UserTeste",
                    Avatar = "AvatarTeste"
                }
            };
        }

        [Test]
        public async Task GetAsync_Called_ReturnListProjeto()
        {
            // Arrange
            var projetoService = GetProjetoService();

            _mockProjetoRepository.Setup(x => x.GetAsync()).ReturnsAsync(It.IsAny<List<Projeto>>());

            // Act
            var result = await projetoService.GetAsync();

            // Assert
            Assert.That(result, Is.EqualTo(It.IsAny<List<Projeto>>()));
        }

        [Test]
        public async Task GetAsync_CalledWithId_ReturnProjeto()
        {
            // Arrange
            var projetoService = GetProjetoService();

            _mockProjetoRepository.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(It.IsAny<Projeto>());

            // Act
            var result = await projetoService.GetAsync(It.IsAny<string>());

            // Assert
            Assert.That(result, Is.EqualTo(It.IsAny<Projeto>()));
        }

        [Test]
        public async Task CreateAsync_CalledWithInValidProjeto_ReturnException()
        {
            // Arrange
            var projetoService = GetProjetoService();

            try
            {
                // Act
                await projetoService.CreateAsync(GetValidProjeto());
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e.Message, Is.EqualTo("Projeto Inválido!"));
            }
        }

        [Test]
        public async Task UpdateAsync_CalledWithInValidProjeto_ReturnException()
        {
            // Arrange
            var projetoService = GetProjetoService();

            try
            {
                // Act
                await projetoService.UpdateAsync(It.IsAny<string>(), GetValidProjeto());
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e.Message, Is.EqualTo("Projeto Inválido!"));
            }
        }

        [Test]
        public void IsValid_InvalidProjeto_ReturnFalse()
        {
            // Arrange
            var projetoService = GetProjetoService();

            var projeto = new Projeto();

            // Act
            var result = projetoService.IsValid(projeto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_ValidProjeto_ReturnTrue()
        {
            // Arrange
            var projetoService = GetProjetoService();

            var projeto = GetValidProjeto();

            // Act
            var result = projetoService.IsValid(projeto);

            // Assert
            Assert.IsTrue(result);
        }
    }
}