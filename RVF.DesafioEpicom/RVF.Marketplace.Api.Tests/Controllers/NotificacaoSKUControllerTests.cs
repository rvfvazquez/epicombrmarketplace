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
    public class NotificacaoSKUControllerTests
    {
        private int idSKU;

        public NotificacaoSKUControllerTests()
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
        public void PostNotificaoSKUTest()
        {
            Task.Run(async () =>
            {
                RVF.Marketplace.Models.NotificacaoSKU notificacaosku = new Models.NotificacaoSKU();

                notificacaosku.dataEnvio = DateTime.Now;
                notificacaosku.parametros = new Models.Parametros();
                notificacaosku.parametros.idProduto = 100;
                notificacaosku.parametros.idSku = 1;
                notificacaosku.parametros.preco = 777;
                NotificacaoSKUController controller = new NotificacaoSKUController();

                System.Web.Http.IHttpActionResult ar = await controller.PostNotificacaoSKU(notificacaosku);

                
                


            }).GetAwaiter().GetResult();
        }
        
    }
}