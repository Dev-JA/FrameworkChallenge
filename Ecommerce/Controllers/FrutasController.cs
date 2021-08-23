using Ecommerce.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrutasController : ControllerBase
    {
        private readonly CRUDContext CRUDConTxt;

        public FrutasController(CRUDContext CRUD)
        {
            CRUDConTxt = CRUD;
        }

        // GET: api/<FrutasController>
        [HttpGet]
        public IEnumerable<Fruta> Get()
        {
            return CRUDConTxt.Frutas;
        }

        // GET api/<FrutasController>/5
        [HttpGet("{id}")]
        public Fruta Get(int id)
        {
            return CRUDConTxt.Frutas.SingleOrDefault(x => x.FrutaID == id);
        }

        // POST api/<FrutasController>
        [HttpPatch("{id}/{quantidade}")]
        public object Patch(int id, int quantidade)
        {
            var item = CRUDConTxt.Frutas.SingleOrDefault(x => x.FrutaID == id);
            if (item == null)
            {
                return StatusCode(404);
            }

            if (item.QuantidadeEstoque < quantidade)
            {
                return StatusCode(420);
            };

            item.QuantidadeEstoque -= quantidade;
            CRUDConTxt.SaveChanges();

            return item;
        }

        // POST api/<FrutasController>
        [HttpPost]
        public object Post([FromBody] Fruta fruta)
        {
            CRUDConTxt.Frutas.Add(fruta);
            CRUDConTxt.SaveChanges();
            return fruta;
        }

        // PUT api/<FrutasController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Fruta fruta)
        {
            var item = CRUDConTxt.Frutas.SingleOrDefault(x => x.FrutaID == id);
            if (item == null)
            {
                return StatusCode(404);
            }
            item.Nome = fruta.Nome;
            item.Descricao = fruta.Descricao;
            item.QuantidadeEstoque = fruta.QuantidadeEstoque;
            item.Valor = fruta.Valor;

            CRUDConTxt.SaveChanges();
            return item;
        }

        // DELETE api/<FrutasController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var item = CRUDConTxt.Frutas.SingleOrDefault(x => x.FrutaID == id);
            if (item == null)
            {
                return StatusCode(404);
            }
            CRUDConTxt.Frutas.Remove(item);
            CRUDConTxt.SaveChanges();
            return item;
        }
    }
}
