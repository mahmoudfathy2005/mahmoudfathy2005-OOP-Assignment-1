using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    internal class Order
    {
        private readonly List<OrderLine> _lines = new();

        public int Id { get; }
        public Customer Customer { get; }
        public DateTime Date { get; }
        public bool IsPaid { get; private set; }

        public IReadOnlyList<OrderLine> Lines => _lines;

        public Order(int id, Customer customer, DateTime date)
        {
            Id = id;
            Customer = customer;
            Date = date;
            IsPaid = false;
        }

        public bool AddLine(Product product, int quantity)
        {
            if (IsPaid)
                return false;

            if (quantity <= 0)
                return false;

            if (!product.ReduceStock(quantity))
                return false;

            _lines.Add(new OrderLine(product, quantity));

            return true;
        }

        public double CalculateTotal()
        {
            double total = 0;

            foreach (OrderLine line in _lines)
            {
                total += line.CalculateTotal();
            }

            if (Customer.IsVip)
            {
                total *= 0.90;
            }

            return total;
        }

        public bool MarkAsPaid()
        {
            if (_lines.Count == 0)
                return false;

            IsPaid = true;
            return true;
        }
    }
}
