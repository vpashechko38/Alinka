using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { success = true, message = _context.Products.ToList() });
        }
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            _context.Add(product);
            return Ok(new { success = true, message = product });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Product product)
        {
            if (product == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            Product prod = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (prod == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            prod = product;
            _context.SaveChanges();
            return Ok(new { success = true, message = prod });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            _context.Products.Remove(product);
            return Ok(new { success = true, message = product });
        }
    }
}

