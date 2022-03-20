using Project.Domain;
using Project.Domain.Interfaces;
using Project.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Project.Repository;
public class EmployeeRepository : IEmployeeRepository
{
    public async Task DeleteAsync(int employeeId)
    {
        using(var db = new MyContext()) 
        {
            var employee = await db.Employees.FindAsync(employeeId);
            if(employee != null)
            {
                db.Employees.Remove(employee);   
                await db.SaveChangesAsync();
            } 
        }
    }

    public async Task EditAsync(Employee employee)
    {
        using(var db = new MyContext()) 
        {
            db.Attach(employee);
            db.Entry<Employee>(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        using(var db = new MyContext()) 
        {
            return await db.Employees.ToListAsync();
        }
    }

    public async Task<Employee?> GetByIdAsync(int employeeId)
    {
        using(var db = new MyContext())
        {
            return await db.Employees.Where(w=> w.Id == employeeId).FirstOrDefaultAsync();
        }
    }

    public async Task InsertAsync(Employee employee)
    {
        using(var db = new MyContext()) 
        {
            await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
        }
    }
}
