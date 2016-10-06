using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RVF.Marketplace.Models;
using RVF.Marketplace.DAL.Repositorios;
using RVF.Marketplace.DAL;


namespace RVF.Marketplace.Api.Controllers
{
    public class SKUsController : ApiController
    {
        
        private IRepositorio<SKU> repositorioSKU;

        public SKUsController()
        {
            repositorioSKU = new SKURepositorio();
        }

        public SKUsController(IRepositorio<SKU> irepositorio)
        {
            this.repositorioSKU = irepositorio;
        }

        // GET: api/SKUs
        public IQueryable<SKU> GetSKUs()
        {
            return repositorioSKU.GetAll();
        }

        // GET: api/SKUs/filtro
        [Route("api/SKUs/preco/{precode}/ate/{precoate}")]
        public IQueryable<SKU> GetSKUsRange(decimal precode, decimal precoate)
        {
            return repositorioSKU.Get(f => f.preco >= precode && f.preco <= precoate);
        }

        // GET: api/SKUs/5
        [ResponseType(typeof(SKU))]
        public async Task<IHttpActionResult> GetSKU(int id)
        {
            SKU sKU = await repositorioSKU.FindAsync(id);

            if (sKU == null)
            {
                return NotFound();
            }

            return Ok(sKU);
        }

        // PUT: api/SKUs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSKU(int id, SKU sKU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sKU.idSKU)
            {
                return BadRequest();
            }

            repositorioSKU.Atualizar(sKU);

            try
            {
                repositorioSKU.SalvarTodos();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SKUExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SKUs
        [ResponseType(typeof(SKU))]
        public async Task<IHttpActionResult> PostSKU(SKU sKU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repositorioSKU.Adicionar(sKU);
            repositorioSKU.SalvarTodos();

            return CreatedAtRoute("DefaultApi", new { id = sKU.idSKU }, sKU);
        }

        // DELETE: api/SKUs/5
        [ResponseType(typeof(SKU))]
        public async Task<IHttpActionResult> DeleteSKU(int id)
        {
            SKU sKU = repositorioSKU.Find(id);
            if (sKU == null)
            {
                return NotFound();
            }

            repositorioSKU.Excluir(f => f.idSKU == sKU.idSKU);
            repositorioSKU.SalvarTodos();

            return Ok(sKU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
             //   db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SKUExists(int id)
        {
            return repositorioSKU.Find(id) != null ;
        }
    }
}