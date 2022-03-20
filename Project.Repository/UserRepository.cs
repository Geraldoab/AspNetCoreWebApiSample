using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Repository
{
    public class UserRepository : IUserRepository
    {
        public User? Find(string username, string password)
        {
            var list = new List<User>();
            list.Add(new User()
            {
                Id = 1,
                Username = "Geraldo",
                Password = "123",
                Role = "manager"
            });

            return list.Where(w=> w.Password.ToLower() == password.ToLower() && w.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }
    }
}