using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Domain.Interfaces;
using Project.Domain.Model;
using Project.Services;

namespace Project.Tests
{
    [TestClass]
    public class TokenServiceTest
    {
        private readonly Mock<ITokenRepository> repository;
        private readonly TokenService service;
        private readonly User validUser = new User()
        {   
            Id = 1,
            Username = "Geraldo",
            Password = "123",
            Role = "Manager"
        };

        public TokenServiceTest()
        {
            repository = new Mock<ITokenRepository>();
            repository.Setup(s=> s.Generate(It.IsAny<User>())).Returns("MyJwtToken");

            service = new TokenService(repository.Object);
        }

        [TestMethod("Should returns a valid Jwt token")]
        public void GenerateValidJwtToken()
        {
            var returnedToken = service.Generate(validUser);
            Assert.IsNotNull(returnedToken);
        }
    }
}