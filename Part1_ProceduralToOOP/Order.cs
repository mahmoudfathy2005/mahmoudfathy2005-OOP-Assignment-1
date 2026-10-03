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
    }
}
