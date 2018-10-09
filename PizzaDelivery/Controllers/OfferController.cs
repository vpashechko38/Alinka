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
    public class OfferController:Controller
    {
        DataContext _context;
        public OfferController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { success = true, message = _context.Offers.ToList() });
        }
        [HttpPost]
        public IActionResult Post([FromBody]Offer offer)
        {
            if (offer == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            _context.Add(offer);
            return Ok(new { success = true, message = offer });
        }
        [HttpPut]
        public IActionResult Put([FromBody]Offer offer)
        {
            if (offer == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            Offer off = _context.Offers.FirstOrDefault(x => x.Id == offer.Id);
            if (off == null)
            {
                return Ok(new { success = false, message = "BadRequest" });
            }
            off = offer;
            _context.SaveChanges();
            return Ok(new { success = true, message = off });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Offer offer = _context.Offers.FirstOrDefault(x => x.Id == id);
            _context.Offers.Remove(offer);
            return Ok(new { success = true, message = offer });
        }
    }
}
