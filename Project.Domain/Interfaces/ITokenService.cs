using Project.Domain.Model;

namespace Project.Domain.Interfaces
{
    public interface ITokenService
    {
        public string Generate(User user);
    }
}