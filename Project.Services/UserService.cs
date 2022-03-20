using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public User? Find(string username, string password)
        {
            return repository.Find(username, password);
        }
    }
}