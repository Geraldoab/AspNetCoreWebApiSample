using Project.Domain.Interfaces;
using Project.Domain.Model;

namespace Project.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository repository;

        public TokenService(ITokenRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public string Generate(User user)
        {
            return repository.Generate(user);
        }
    }
}