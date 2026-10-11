namespace Part3_BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Create Billing Address
            var billingAddress = new AddressBuilder()
                .WithStreet("12 Main Street")
                .WithCity("Cairo")
                .WithState("Cairo")
                .WithZipCode("11511")
                .WithCountry("Egypt")
                .Build();

            // Create Shipping Address
            var shippingAddress = new AddressBuilder()
                .WithStreet("25 Nile Street")
                .WithCity("Giza")
                .WithState("Giza")
                .WithZipCode("12511")
                .WithCountry("Egypt")
                .Build();

            // Create Order
            var order = new OrderBuilder()
                .WithOrderDate(DateTime.Today)
                .WithPaymentMethod("Credit Card")
                .WithCurrency("USD")
                .WithSubTotal(1000m)
                .WithDiscountAmount(100m)
                .WithTaxAmount(90m)
                .WithTotalAmount(990m)
                .Build();

            // Create Invoice
            var invoice = new InvoiceBuilder()
                .WithInvoiceId("INV-1001")
                .WithCustomerName("Ahmed")
                .WithCustomerEmail("ahmed@example.com")
                .WithCustomerPhone("01000000000")
                .WithBillingAddress(billingAddress)
                .WithShippingAddress(shippingAddress)
                .WithOrder(order)
                .Build();

            // Display result
            Console.WriteLine("Invoice Created Successfully!");
            Console.WriteLine($"Invoice ID: {invoice.InvoiceId}");
            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Email: {invoice.CustomerEmail}");
            Console.WriteLine($"Billing City: {invoice.BillingAddress.City}");
            Console.WriteLine($"Shipping City: {invoice.ShippingAddress.City}");
            Console.WriteLine($"Total Amount: {invoice.Order.TotalAmount}");





        }
    }
}
