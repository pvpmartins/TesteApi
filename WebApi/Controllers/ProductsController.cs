using Application.Entities;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Produtos>> Get([FromQuery] string term, int page, int pageSize)
        {
            var pag = _service.GetAll(term, page, pageSize);

            return Ok(pag);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<dynamic>> Post([FromBody] Produtos produto)
        {
            if (produto.Nome == null || produto.Nome == "")
            {
                return BadRequest(new { message = "Por favor, forneça um nome." });
            }

            if (!(produto.PrecoUnitario > 0))
            {
                return BadRequest(new { message = "Por favor, informe um valor unitario maior do que 0." });
            }

            if (!(produto.QuantidadeEstoque > 0))
            {
                return BadRequest(new { message = "Por favor, informe uma quantidade de estoque maior do que 0." });
            }

            try {
                _service.Add(produto);
            }catch (Exception err)
            {
                return BadRequest(new { message = "Esse produto ja esta cadastrado." });
            }

            return Ok(produto);
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Put(int id, [FromBody] Produtos produto)
        {
            if (produto.Nome == null || produto.Nome == "")
            {
                return BadRequest(new { message = "Por favor, forneça um nome." });
            }
            if (!(produto.PrecoUnitario > 0))
            {
                return BadRequest(new { message = "Por favor, informe um valor unitario maior do que 0." });
            }

            if (!(produto.QuantidadeEstoque > 0))
            {
                return BadRequest(new { message = "Por favor, informe uma quantidade de estoque maior do que 0." });
            }
            try
            {
                _service.Update(produto, id);
            } catch(Exception e)
            {
                return BadRequest(new { message = "Produto não cadastrado." });
            }

            return Ok(produto);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Produto não cadastrado." });
            }
            return Ok("Produto deletado!");
        }
    }
}
