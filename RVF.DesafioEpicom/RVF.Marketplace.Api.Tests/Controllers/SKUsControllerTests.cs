using Microsoft.VisualStudio.TestTools.UnitTesting;
using RVF.Marketplace.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RVF.Marketplace.Api.Controllers.Tests
{
    [TestClass()]
    public class SKUsControllerTests
    {
        private int idSKU;

        public SKUsControllerTests()
        {
            Inicializar();
        }
        //[TestInitialize]
        public void Inicializar() {
            var appDataDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", appDataDir);
            idSKU = 1;
        }

        [TestMethod()]
        public void ReadSKUsTest()
        {
            SKUsController controller = new SKUsController();
            var skus = controller.GetSKUs().Where(f=>f.idSKU == idSKU) ;
            Assert.AreEqual( skus.ToList().Count , 1);
        }

        [TestMethod()]
        public void ReadSKUTest()
        {
            SKUsController controller = new SKUsController();

            Task.Run(async () =>
            {
                System.Web.Http.IHttpActionResult sku = await controller.GetSKU(idSKU);
            }).GetAwaiter().GetResult();
            
             
        }

        [TestMethod()]
        public void PutSKUTest()
        {
            Task.Run(async () =>
            {
                RVF.Marketplace.Models.SKU sku = new Models.SKU();
                
                sku.idSKU = idSKU;
                sku.idProduto = 100;
                sku.preco = 200;
                sku.DataCriacao = DateTime.Now;
                sku.DataAlteracao = DateTime.Now;
                SKUsController controller = new SKUsController();
                await controller.PutSKU(idSKU,sku);
            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void PostSKUTest()
        {
            Task.Run(async () =>
            {
                RVF.Marketplace.Models.SKU sku = new Models.SKU();
                sku.idSKU = 1;
                sku.idProduto = 100;
                sku.preco = 15;
                sku.DataCriacao = DateTime.Now;
                sku.DataAlteracao = DateTime.Now;
                SKUsController controller = new SKUsController();
                System.Web.Http.IHttpActionResult ar = await controller.PostSKU(sku);

                var skuposted = ((System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<RVF.Marketplace.Models.SKU>)ar).Content;
                idSKU = skuposted.idSKU;


            }).GetAwaiter().GetResult();
        }

        [TestMethod()]
        public void RemoveSKUTest()
        {
            Task.Run(async () =>
            {
                int idSKU = 1;
                SKUsController controller = new SKUsController();
                await controller.DeleteSKU(idSKU);
            }).GetAwaiter().GetResult();
        }
    }
}