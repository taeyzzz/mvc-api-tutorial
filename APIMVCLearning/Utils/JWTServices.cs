using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIMVCLearning.Models;
using Microsoft.IdentityModel.Tokens;

namespace APIMVCLearning.Utils
{
    public class JWTServices
    {
        private readonly string SECRET_KEY = "this is my super secret key";
        private readonly JwtSecurityTokenHandler tokenHandler;

        public JWTServices()
        {
            tokenHandler = new JwtSecurityTokenHandler();
        }

        public string generateJWTToken(User userData)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("email", userData.email)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY)),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public object verifyJWTToken(string token)
        {
            var data = tokenHandler.ReadJwtToken(token).Payload;
            var email = data["email"];
            return email;
        }
    }
}