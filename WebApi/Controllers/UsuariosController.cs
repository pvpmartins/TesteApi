using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Application.Repositories;
using Application.Entities;
using Application.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepo _repository;


        public UsuariosController(IUsuarioRepo repository)
        {
            _repository = repository;
        }

      

        // private readonly MockUsuarioRepo _repository = new MockUsuarioRepo();
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult <IEnumerable<Usuarios>> Get()
        {
            var usuariosList = _repository.GetUsuarios();

            return Ok(usuariosList);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Usuarios> Get(int id)
        {
            var usuario = _repository.getUsuariosById(id);

            return Ok(usuario);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
