using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Controllers
{
    [Route("api/[controller]")]
    public class IngredientController:Controller
    {
        DataContext _context;
        public IngredientController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { success = true, message = _context.Ingredients.ToList() });
        }
        [HttpPost]
        public IActionResult Post([FromBody]Ingredient ingred)
        {
            if (ingred == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            _context.Ingredients.Add(ingred);
            _context.SaveChanges();
            return Ok(new { success = true, message = ingred });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Ingredient ingred)
        {
            if (ingred == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            Ingredient ingredient = _context.Ingredients.FirstOrDefault(x => x.Id == ingred.Id);
            if (ingredient==null)
            {
                return Ok(new { success = false, message = "Объект не найден" });
            }
            _context.Ingredients.Update(ingred);
            _context.SaveChanges();
            return Ok(new { success = true, message = ingred });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Ingredient ing = _context.Ingredients.FirstOrDefault(x => x.Id == id);
            _context.Ingredients.Remove(ing);
            _context.SaveChanges();
            return Ok(new { success = true, message = ing });
        }
    }
}
