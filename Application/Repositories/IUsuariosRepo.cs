using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IUsuariosRepo
    {
        IEnumerable<Usuarios> GetUsuarios();

        Usuarios GetUsuariosById(int id);

        Usuarios GetUser(string username, string password, string email);
    }
}
