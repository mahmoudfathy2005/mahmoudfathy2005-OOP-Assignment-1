using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    internal class Product
    {


        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }
        public Product(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public bool ReduceStock(int quantity)
        {
            if (quantity <= Stock & quantity > 0)
            {
                Stock -= quantity;
                return true;
            }
            return false;



        }
        public override string ToString()
        {
            return $"{Id} - {Name} - Price: {Price:F2} - Stock: {Stock}";
        }


    }
}
