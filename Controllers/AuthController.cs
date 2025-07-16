using EgyptWalks.Models.DTo;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser()
            {
                UserName = registerRequestDto.UserName,
                Email = registerRequestDto.UserName
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                if (registerRequestDto.Roles is not null && registerRequestDto.Roles.Any())
                {
                   identityResult =  await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User was Registered! Please Login.");
                    }
                }

            }


            return BadRequest("Something Went Wrong!");
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.UserName);

            if(user is not null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if(checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if(roles is not null)
                    {
                        var jwtToken = tokenRepository.CreateJwtToken(user,roles.ToList());

                        var response = new LoginResponseDto()
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }
                }
            }

            return BadRequest("User Name Or Password is Wrong!");


        }
    }
}
