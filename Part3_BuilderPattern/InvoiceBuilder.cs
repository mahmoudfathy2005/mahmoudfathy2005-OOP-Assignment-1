using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    public class InvoiceBuilder
    {
        private string? _invoiceId;
        private string? _customerName;
        private string? _customerEmail;
        private string? _customerPhone;

        private Address? _billingAddress;
        private Address? _shippingAddress;
        private Order? _order;

        public InvoiceBuilder WithInvoiceId(string value)
        {
            _invoiceId = value;
            return this;
        }

        public InvoiceBuilder WithCustomerName(string value)
        {
            _customerName = value;
            return this;
        }

        public InvoiceBuilder WithCustomerEmail(string value)
        {
            _customerEmail = value;
            return this;
        }

        public InvoiceBuilder WithCustomerPhone(string value)
        {
            _customerPhone = value;
            return this;
        }

        public InvoiceBuilder WithBillingAddress(Address value)
        {
            _billingAddress = value;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Address value)
        {
            _shippingAddress = value;
            return this;
        }

        public InvoiceBuilder WithOrder(Order value)
        {
            _order = value;
            return this;
        }

        public Invoice Build()
        {
            if (string.IsNullOrWhiteSpace(_invoiceId))
                throw new InvalidOperationException("InvoiceId is required.");

            if (string.IsNullOrWhiteSpace(_customerName))
                throw new InvalidOperationException("CustomerName is required.");

            if (string.IsNullOrWhiteSpace(_customerEmail))
                throw new InvalidOperationException("CustomerEmail is required.");

            if (_billingAddress == null)
                throw new InvalidOperationException("BillingAddress is required.");

            if (_shippingAddress == null)
                throw new InvalidOperationException("ShippingAddress is required.");

            if (_order == null)
                throw new InvalidOperationException("Order is required.");

            return new Invoice(
                _invoiceId,
                _customerName,
                _customerEmail,
                _customerPhone ?? "",
                _billingAddress,
                _shippingAddress,
                _order
            );
        }
    }

}
