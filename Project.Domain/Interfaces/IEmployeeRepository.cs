using Project.Domain.Model;

namespace Project.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
         public Task<IEnumerable<Employee>> GetAllAsync();
         public Task<Employee?> GetByIdAsync(int employeeId);
         public Task InsertAsync(Employee employee);
         public Task EditAsync(Employee employee);
         public Task DeleteAsync(int employeeId); 
    }
}