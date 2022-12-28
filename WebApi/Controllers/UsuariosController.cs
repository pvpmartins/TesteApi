using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Application.Entities;
using Application.Context;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using Application.Services.Interfaces;
using Application.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _service;
        private readonly IUsuariosRepo _repository;

        public UsuariosController(IUsuariosService service, IUsuariosRepo repository)
        {
            _service = service;
            _repository = repository;
        }



        // private readonly MockUsuarioRepo _repository = new MockUsuarioRepo();
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult <IEnumerable<Usuarios>> Get()
        {
            var usuariosList = _service.GetAllUsuarios();

            return Ok(usuariosList);
        }
        
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult <Usuarios> Get(int id)
        {
            var usuario = _repository.GetUsuariosById(id);

            return Ok(usuario); 
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuarios model)
        {
            var user = _repository.GetUser(model.Nome, model.Senha, model.Email);
            if (user == null)
                return NotFound(new { message = "Usuario ou Senha invalidos" });

            var token = UsuariosService.GenerateToken(user);
            user.Senha = "";
            return new
            {
                user = user,
                token = token
            };
        }
        
        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

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
