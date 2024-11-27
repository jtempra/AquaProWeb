using AquaProWeb.Common.Models;
using AquaProWeb.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AquaProWeb.Common.Authentication;
using static AquaProWeb.Common.Models.CustomResponses;


namespace AquaProWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        //Contructor with Instances.
        private readonly AuthDbContext _authDbContext;
        private readonly IConfiguration _config;
        public AuthenticationController(AuthDbContext authDbContext, IConfiguration config)
        {
            _authDbContext = authDbContext;
            _config = config;
        }

        // Account Registration
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterModel model)
        {

            //Check if the email is already used in registration.
            var user = await _authDbContext.Registration.FirstOrDefaultAsync(_ => _.Email!.ToLower().Equals(model.Email!.ToLower()));

            if (user is not null)
            {
                return BadRequest(new RegistrationResponse { Flag = false, Message = "El email ya está dado de alta con otra cuenta!" });
            }


            var entity = _authDbContext.Registration.Add(
                new Register()
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                }).Entity;

            await _authDbContext.SaveChangesAsync();


            //Save the Role asigned to the database   

            _authDbContext.UserRoles.Add(new UserRole() { RoleName = model.Role, UserId = entity.Id });

            await _authDbContext.SaveChangesAsync();

            return Ok(new RegistrationResponse { Flag = true, Message = $"Dado de alta el usuario con ID {entity.Id}" });
        }

        // Account login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginUser(LoginModel model)
        {
            //Check if user email exist
            var user = await _authDbContext.Registration.FirstOrDefaultAsync(_ => _.Email!.ToLower().Equals(model.Email!.ToLower()));
            if (user is null)
                return BadRequest(new LoginResponse { Flag = false, Message = "El email no existe!" });

            if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                //Find User Role from the User-role table
                var getRole = await _authDbContext.UserRoles.FirstOrDefaultAsync(_ => _.UserId == user.Id);
                if (getRole is null)
                    return BadRequest(new LoginResponse { Flag = false, Message = "El usuario no tiene rol definido!" });


                //Generate Token
                var token = GenerateToken(user.Name, model.Email, getRole.RoleName);

                // Generate Refresh Token
                var refreshToken = GenerateRefreshToken();

                //Check if user has refresh token already.
                var chkUserToken = await _authDbContext.TokenInfo.FirstOrDefaultAsync(_ => _.UserId == user.Id);
                if (chkUserToken is null)
                {
                    //Save the refreshtoken to the TokenInfo table
                    _authDbContext.TokenInfo.Add(new TokenInfo()
                    { RefreshToken = refreshToken, UserId = user.Id, TokenExpiry = DateTime.UtcNow.AddMinutes(2) });
                    await _authDbContext.SaveChangesAsync();
                }
                else
                {
                    // Update the the refresh token
                    chkUserToken.RefreshToken = refreshToken;
                    chkUserToken.TokenExpiry = DateTime.Now.AddMinutes(2);
                    await _authDbContext.SaveChangesAsync();
                }
                return Ok(new LoginResponse { Flag = true, Message = "Sesión creada", UserSession = new UserSession { Token = token, RefreshToken = refreshToken } });
            }

            return BadRequest(new LoginResponse { Flag = false, Message = "Los passwords no coinciden!" });
        }



        // General Methods for token and refresh token generating.
        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        private string GenerateToken(string? name, string? email, string? roleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name,name!),
                new Claim(ClaimTypes.Email,email!),
                new Claim(ClaimTypes.Role,roleName!)
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        //PUBLIC API ENPOINT FOR GENERATING NEW REFRESH TOKEN AND AUTHENTICATION TOKEN
        [HttpPost("GetNewToken")]
        [AllowAnonymous]
        public async Task<ActionResult<UserSession>> GetNewToken(UserSession userSession)
        {
            if (userSession is null)
                return null!;
            var rToken = await _authDbContext.TokenInfo.Where(_ => _.RefreshToken!.Equals(userSession.RefreshToken)).FirstOrDefaultAsync();

            // check if refresh token expiration date is due then.
            if (rToken is null)
                return null!;

            //Generate new refresh token if Due.
            string newRefreshToken = string.Empty;
            if (rToken.TokenExpiry < DateTime.Now)
                newRefreshToken = GenerateRefreshToken();

            //Generate new token by extracting the claims from the old jwt 
            var jwtToken = new JwtSecurityToken(userSession!.Token);
            var userClaims = jwtToken.Claims;

            //Get all claims from the token.
            var name = userClaims.First(c => c.Type == ClaimTypes.Name).Value;
            var email = userClaims.First(c => c.Type == ClaimTypes.Email).Value;
            var role = userClaims.First(c => c.Type == ClaimTypes.Role).Value;
            string newToken = GenerateToken(name, email, role);

            //update refresh token in the DB
            var user = await _authDbContext.Registration.FirstOrDefaultAsync(_ => _.Email.ToLower().Equals(email.ToLower()));
            var rTokenUser = await _authDbContext.TokenInfo.FirstOrDefaultAsync(_ => _.UserId == user.Id);

            if (!string.IsNullOrEmpty(newRefreshToken))
            {
                rTokenUser.RefreshToken = newRefreshToken;
                rTokenUser.TokenExpiry = DateTime.Now.AddMinutes(1);
                await _authDbContext.SaveChangesAsync();
            }
            return Ok(new UserSession() { Token = newToken, RefreshToken = newRefreshToken });

        }
    }
}
