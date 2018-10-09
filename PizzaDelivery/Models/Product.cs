using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public bool IsActivity { get; set; }
        public string Photo { get; set; }

        public string Price { get; set; }
        public int Discount { get; set; }

        public int Size { get; set; }
        public int Weight { get; set; }

        public double Kkal { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
