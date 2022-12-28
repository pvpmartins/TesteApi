using Application.Context;
using Application.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Repositories
{
    public class CategoriasRepo :ICategoriasRepo
    {
        private readonly ProvaContext _context;

        public CategoriasRepo(ProvaContext context)
        {
            _context = context; 
        }

        public IEnumerable<Categorias> GetAllCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categorias GetCategoryById(int id)
        {
            return _context.Categorias.FirstOrDefault(p => p.Id == id);
        }

        public void AddCategoria(Categorias categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChangesAsync();
        }

        public Categorias GetCategoriaByName(string nome)
        {
            return _context.Categorias.FirstOrDefault(
                categoria => categoria.Nome == nome
            );
        }
    }
}
