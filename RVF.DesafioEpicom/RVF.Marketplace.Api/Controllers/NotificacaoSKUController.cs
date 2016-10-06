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
    public class NotificacaoSKUController : ApiController
    {
        //private MarketplaceContext db = new MarketplaceContext();

        private IRepositorio<SKU> repositorioSKU ;

        public NotificacaoSKUController()
        {
            repositorioSKU = new SKURepositorio();
        }

        public NotificacaoSKUController(IRepositorio<SKU> repositorio )
        {
           repositorioSKU = repositorio;
        }


        // POST: api/SKUs/Notificacao
        [ResponseType(typeof(NotificacaoSKU))]
        [Route("api/SKUs/Notificacao")]
        public async Task<IHttpActionResult> PostNotificacaoSKU(NotificacaoSKU notificacaoSKU)
        {
            
            //db.EventosMarketplace.Add(notificacaoSKU);

            //await db.SaveChangesAsync();

            int? idSKU = notificacaoSKU.parametros.idSku;

            SKU sKU =  await repositorioSKU.FindAsync(idSKU);

            if (sKU == null)
            {
                return NotFound();
            }

            repositorioSKU.Atualizar(sKU);
            
            sKU.idProduto   = notificacaoSKU.parametros.idProduto.HasValue ? notificacaoSKU.parametros.idProduto.Value : sKU.idProduto;
            sKU.preco       = notificacaoSKU.parametros.idProduto.HasValue ? notificacaoSKU.parametros.preco.Value : sKU.preco;


            repositorioSKU.SalvarTodos();

            return Ok(sKU);


        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}