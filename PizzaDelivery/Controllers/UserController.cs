using Microsoft.AspNetCore.Mvc;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { success = true, message = _context.Users.ToList() });
        }
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new { success = true, message = user });
        }
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            if (user == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            User client = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            client = user;
            _context.SaveChanges();
            return Ok(new { success = true, message = client });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User deleteUser = _context.Users.FirstOrDefault(x=>x.Id == id);
            if (deleteUser == null)
            {
                return Ok(new { success = false, message = "Указанный пользователь не найден" });
            }
            _context.Remove(deleteUser);
            _context.SaveChanges();
            return Ok(new { success = true, message = deleteUser });
        }
    }
}
