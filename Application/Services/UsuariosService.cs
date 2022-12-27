using Application.Entities;
using Application.Repositories;
using Application.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepo _repository;
        public UsuariosService(IUsuariosRepo repository) {
            _repository = repository;
        }
        public IEnumerable<Usuarios> GetAllUsuarios()
        {
            return _repository.GetUsuarios();
        }
        public static string GenerateToken(Usuarios usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
                
            };
            tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public Usuarios DoLogin(string username, string password, string name)
        {
            throw new NotImplementedException();
        }
    }
}
