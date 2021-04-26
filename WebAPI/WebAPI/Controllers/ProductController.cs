using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PipelineLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>();
        public ProductController()
        {
            products.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
            products.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
            products.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
        }
        //public ProductController(List<Product> products)
        //{
        //    this.products = products;
        //}
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
        //[HttpGet]
        //public async Task<IEnumerable<Product>> GetProductAsync()
        //{
        //    return await Task.FromResult(GetProducts());
        //}
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id.Equals(id));
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
