using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Project.Domain.Interfaces;
using Project.Domain.Model;
using Project.Services;

namespace Project.Tests;

[TestClass]
public class EmployeeServiceTest : BaseEmployeeTest
{
    private readonly Mock<IEmployeeRepository> repositoryMock;
    private readonly IEmployeeService service;

    public EmployeeServiceTest()
    {
        repositoryMock = new Mock<IEmployeeRepository>();
        repositoryMock.Setup(s=> s.GetAllAsync()).ReturnsAsync(List);
        repositoryMock.Setup(s=> s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(Employee);
        repositoryMock.Setup(s=> s.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);
        repositoryMock.Setup(s=> s.EditAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);
        repositoryMock.Setup(s=> s.InsertAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

        service = new EmployeeService(repositoryMock.Object);
    }

    [TestMethod("Should insert a new employee")]
    public async Task TestInsertEmployeeAsync()
    {
        await service.InsertAsync(Employee); 
    }

    [TestMethod("Should delete an employee")]
    public async Task TestDeleteEmployeeAsync()
    {
        await service.DeleteAsync(1);
    }

    [TestMethod("Should edit an employee")]
    public async Task TestEditEmployeeAsync()
    {
        await service.EditAsync(Employee);
    }

    [TestMethod("Should return all employees")]
    public async Task TestGetAllAsync()
    {
        var result = await service.GetAllAsync();
        Assert.IsNotNull(result);
    }
}