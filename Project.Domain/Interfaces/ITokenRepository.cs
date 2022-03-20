using Project.Domain.Model;

namespace Project.Domain.Interfaces
{
    public interface ITokenRepository
    {
         public string Generate(User user);
    }
}