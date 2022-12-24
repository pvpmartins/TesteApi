using Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public interface IUsuarioRepo
    {
        IEnumerable<Usuarios>  GetUsuarios();
        Usuarios getUsuariosById(int id);
    }
}
