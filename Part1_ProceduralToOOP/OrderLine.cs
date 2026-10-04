using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    internal class OrderLine
    {


        public Product Product { get; }

        public int Quantity { get; }

        public OrderLine(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
            Product = product;
            Quantity = quantity;
        }

        public double CalculateTotal()
        {
            return (double)Product.Price * Quantity;
        }

    }
}
