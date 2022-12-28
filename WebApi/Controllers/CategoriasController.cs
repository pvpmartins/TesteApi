using Application.Entities;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriasService _service;

        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }
        // GET: api/<CategoriasController>
        [HttpGet]
        public IEnumerable<Categorias> Get()
        {
            return _service.GetAll();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Post([FromBody] Categorias categoria)
        {
           if(categoria.Nome == null)
            {
                return BadRequest(new { message = "Por favor, forneça um nome." });
            }
            try
            {
                _service.AddCategoria(categoria);
            } catch(Exception err) {
                return BadRequest(new { message = "Essa categoria ja esta cadastrada." });
            }    

            return Ok();
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
