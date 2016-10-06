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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using RVF.Marketplace.Models;
using RVF.Marketplace.DAL;

namespace RVF.Marketplace.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using RVF.Marketplace.Api.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SKU>("SKUsOData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SKUsODataController : ODataController
    {
        private MarketplaceContext db = new MarketplaceContext();

        // GET: odata/SKUsOData
        [EnableQuery]
        public IQueryable<SKU> GetSKUsOData()
        {
            return db.SKUs;
        }

        // GET: odata/SKUsOData(5)
        [EnableQuery]
        public SingleResult<SKU> GetSKU([FromODataUri] int key)
        {
            return SingleResult.Create(db.SKUs.Where(sKU => sKU.idSKU == key));
        }

        // PUT: odata/SKUsOData(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<SKU> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SKU sKU = await db.SKUs.FindAsync(key);
            if (sKU == null)
            {
                return NotFound();
            }

            patch.Put(sKU);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SKUExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sKU);
        }

        // POST: odata/SKUsOData
        public async Task<IHttpActionResult> Post(SKU sKU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SKUs.Add(sKU);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SKUExists(sKU.idSKU))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(sKU);
        }

        // PATCH: odata/SKUsOData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SKU> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SKU sKU = await db.SKUs.FindAsync(key);
            if (sKU == null)
            {
                return NotFound();
            }

            patch.Patch(sKU);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SKUExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(sKU);
        }

        // DELETE: odata/SKUsOData(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            SKU sKU = await db.SKUs.FindAsync(key);
            if (sKU == null)
            {
                return NotFound();
            }

            db.SKUs.Remove(sKU);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SKUExists(int key)
        {
            return db.SKUs.Count(e => e.idSKU == key) > 0;
        }
    }
}
