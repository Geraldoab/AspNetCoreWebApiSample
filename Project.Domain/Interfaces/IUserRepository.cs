using Project.Domain.Model;

namespace Project.Domain.Interfaces
{
    public interface IUserRepository
    {
         public User? Find(string username, string password);
    }
}