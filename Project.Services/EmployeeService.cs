using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public async Task DeleteAsync(int employeeId)
        {
            await repository.DeleteAsync(employeeId);
        }

        public async Task EditAsync(Employee employee)
        {
            await repository.EditAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int employeeId)
        {
            return await repository.GetByIdAsync(employeeId);
        }

        public async Task InsertAsync(Employee employee)
        {
            await repository.InsertAsync(employee);
        }
    }
}