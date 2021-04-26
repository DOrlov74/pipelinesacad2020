using Newtonsoft.Json;
using PipelineLib;
using System;
using System.Collections.Generic;
using Xunit;

namespace PipelineXUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }
        [Fact]
        public void GetProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new WebAPI.Controllers.ProductController();
            var result = controller.GetProducts() as List<Product>;
            string a = JsonConvert.SerializeObject(testProducts);
            string b = JsonConvert.SerializeObject(result);
            Assert.Equal(a, b);
        }

        private List<Product> GetTestProducts()
        {
            var testProducts = new List<Product>();
            testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
            testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
            testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
            return testProducts;
        }
    }
}
