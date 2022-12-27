using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interfaces
{
    public interface IUsuariosService
    {
        Usuarios DoLogin(string username, string password, string name);
        //string GenerateToken(Usuarios usuario);
        IEnumerable<Usuarios> GetAllUsuarios();
    }
}
