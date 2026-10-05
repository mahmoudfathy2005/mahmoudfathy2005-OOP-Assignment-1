namespace Part3_BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Address billingAddress =
                new AddressBuilder()
                    .WithStreet("10 Main Street")
                    .WithCity("Cairo")
                    .WithState("Cairo")
                    .WithZipCode("11511")
                    .WithCountry("Egypt")
                    .Build();

            Address shippingAddress =
                new AddressBuilder()
                    .WithStreet("20 Nile Street")
                    .WithCity("Alexandria")
                    .WithState("Alexandria")
                    .WithZipCode("21500")
                    .WithCountry("Egypt")
                    .Build();

            Invoice invoice =
                new OrderBuilder()
                    .WithInvoiceId(1001)
                    .WithCustomer(
                        "Ahmed Ali",
                        "ahmed@example.com",
                        "01000000000")
                    .WithBillingAddress(billingAddress)
                    .WithShippingAddress(shippingAddress)
                    .WithOrderDate(DateTime.Now)
                    .WithPaymentMethod("Credit Card")
                    .WithCurrency("EGP")
                    .WithSubTotal(1000)
                    .WithDiscount(100)
                    .WithTax(90)
                    .Build();

            Console.WriteLine($"Invoice: {invoice.InvoiceId}");
            Console.WriteLine($"Customer: {invoice.CustomerName}");
            Console.WriteLine($"Total: {invoice.TotalAmount}");




        }
    }
}
