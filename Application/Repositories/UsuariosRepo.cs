using Application.Context;
using Application.Entities;
using Application.Services;
using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Repositories
{
    public class UsuariosRepo : IUsuariosRepo
    {
        private readonly ProvaContext _context;

        public UsuariosRepo()
        {

        }
        public UsuariosRepo(ProvaContext context)
        {
            _context = context;
        }
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuarios GetUsuariosById(int id)
        {
            return _context.Usuarios.FirstOrDefault(p => p.Id == id);
        }
        
        public Usuarios GetUser(string username, string password, string email)
        {
            return _context.Usuarios.FirstOrDefault(
                user => user.Nome == username && user.Email == email && user.Senha == password
            );
        }
    }
}
