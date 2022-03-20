using Project.Domain.Model;

namespace Project.Domain.Interfaces
{
    public interface IUserService
    {
         public User? Find(string username, string password);
    }
}