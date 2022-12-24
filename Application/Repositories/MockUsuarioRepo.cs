using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class MockUsuarioRepo : IUsuarioRepo
    {
        public IEnumerable<Usuarios> GetUsuarios()
        {
            var usuarios = new List<Usuarios>
            {
                new Usuarios { Id = 0, Email = "pvpmartins@hotmail.com", Nome = "Paulo", Senha = "123" },
                new Usuarios { Id = 1, Email = "joao@hotmail.com", Nome = "Joao", Senha = "123" },
                new Usuarios { Id = 2, Email = "carlos@hotmail.com", Nome = "Carlos", Senha = "123" }
        };
            return usuarios;    
        }

        public Usuarios getUsuariosById(int id)
        {
            return new Usuarios { Id = 0, Email = "pvpmartins@hotmail.com", Nome = "Paulo", Senha = "123" };
        }
    }
}
