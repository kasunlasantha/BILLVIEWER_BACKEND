using BillPaymentViewer.Core.DomainServices;
using BillPaymentViewer.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace BillPaymentViewer.Core.ApplicationServices.Services
{
    public class LoginService : ILoginService
    {
        public IConfiguration _configuration;
        readonly ILoginRepository _loginRepo;
        public LoginService(IConfiguration config, ILoginRepository loginRepo)
        {
            _configuration = config;
            _loginRepo = loginRepo;



        }
        public async Task<User> Login(User user)
        {
            try
            {
                var loginuser = await _loginRepo.Login(user);
                if (loginuser != null)
                {
                    var token = this.GenerateToken(user.username);                
                    return new User {userlevel = loginuser.USERLEVEL,token = token, username = loginuser.USERNAME};
                }
                else
                {
                    throw new AuthenticationException("Username or password is invalid.");
                }
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public string Logoff(User user)
        {
            throw new NotImplementedException();
        }

        //Create JWT token and it return to user
        public  string GenerateToken(string user)
        {
            //create claims details based on the user information
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserName", user),

                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                expires: DateTime.UtcNow.AddMinutes(5), signingCredentials: signIn);

            return (new JwtSecurityTokenHandler().WriteToken(token));
        }



        private string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

        //example : var hashed = this.HashPassword(user.password);
        private string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }

    }
}
