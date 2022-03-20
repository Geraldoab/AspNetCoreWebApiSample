using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Domain.Interfaces;
using Project.Domain.Model;
using Project.Services;

namespace Project.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> repository;
        private readonly UserService userService;
        private readonly User expectedUser = new User()
        {   
            Id = 1,
            Username = "Geraldo",
            Password = "123",
            Role = "Manager"
        };

        public UserServiceTest()
        {
            repository = new Mock<IUserRepository>();
            repository.Setup(s=> s.Find(It.IsAny<string>(), It.IsAny<string>())).Returns(expectedUser);

            userService = new UserService(repository.Object);
        }

        [TestMethod("Should returns a valid user")]
        public void GetUserTest()
        {
            var returnedUser = userService.Find("Geraldo", "123");
            Assert.AreEqual(expectedUser.Id, returnedUser?.Id);
            Assert.AreEqual(expectedUser.Username, returnedUser?.Username);
            Assert.AreEqual(expectedUser.Password, returnedUser?.Password);
            Assert.AreEqual(expectedUser.Role, returnedUser?.Role);
        }        
    }
}