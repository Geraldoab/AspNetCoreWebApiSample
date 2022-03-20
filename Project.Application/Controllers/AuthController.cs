using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Dto;
using Project.Domain.Interfaces;

namespace Project.Application.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController
    {
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AuthController(ITokenService tokenService,
            IMapper mapper, IUserService userService)
        {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost]
        [Route("Token")]
        public ActionResult<dynamic> Authentication([FromBody] TokenPostRequest request)
        {
            if(request == null)
            {
                return new BadRequestResult();
            }

            var user = userService.Find(request.Username, request.Password);

            if(user == null)
            {
                return new NotFoundResult();
            }

            user.Password = string.Empty;

            var newToken = tokenService.Generate(user);

            return new 
            {
                user = user,
                token = newToken
            };
        }
    }
}