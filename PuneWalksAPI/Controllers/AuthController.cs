using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using PuneWalksAPI.Models.DTO;
using PuneWalksAPI.Repositories;

namespace PuneWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> usermanager;

        public ITokenRepository tokenRepository { get; }

        public AuthController(UserManager<IdentityUser> userManager,ITokenRepository tokenRepository)
        {
           this.usermanager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //POST: /api/Auth/Register

        [HttpPost]
        [Route("Register")]
        public async Task <IActionResult> Register([FromBody]RegisterRequestDTO registerRequestDTO)
        {
            var identityuser = new IdentityUser()
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
             var identityresult = await usermanager.CreateAsync(identityuser, registerRequestDTO.Password);
            if (identityresult.Succeeded)
            {
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityresult = await usermanager.AddToRolesAsync(identityuser, registerRequestDTO.Roles);

                    if (identityresult.Succeeded)
                    {
                        return Ok("User was registered successfully!please login.");
                    }

                }
                
            } 
            return BadRequest(identityresult.Errors);
            
        }

        //POST: /api/Auth/Login

        //POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await usermanager.FindByNameAsync(loginRequestDTO.Username);
            if (user != null)
            {
                var checkpasswordResult = await usermanager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkpasswordResult)
                {
                    //Get Roles for this user
                    var roles = await usermanager.GetRolesAsync(user);

                    var JwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                    var response = new LoginResponseDTO()
                    {
                        JwtToken = JwtToken
                    };
                    return Ok(response.JwtToken);
                }
            }
             return BadRequest("User name or password is incorrect!");
            
        }
    }
}
