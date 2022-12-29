using Application.Entities;
using Application.Repositories;
using Application.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ProductTests
    {
        private IProductsRepo _productsRepo;
        [TestMethod]
        public void GetAll_RequestProducts_ReturnsProduts()
        {
            var service = new ProductsService(_productsRepo);

            var result = service.GetAll("camisa", 1, 1);


            Assert.IsNotNull(result);

        }

        
    }
}
