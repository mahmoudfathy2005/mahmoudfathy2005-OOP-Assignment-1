using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern;

public class OrderBuilder
{
    private int _invoiceId;
    private string? _customerName;
    private string? _customerEmail;
    private string? _customerPhone;

    private Address? _billingAddress;
    private Address? _shippingAddress;

    private DateTime _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private decimal _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;

    public OrderBuilder WithInvoiceId(int id)
    {
        _invoiceId = id;
        return this;
    }

    public OrderBuilder WithCustomer(
        string name,
        string email,
        string phone)
    {
        _customerName = name;
        _customerEmail = email;
        _customerPhone = phone;
        return this;
    }

    public OrderBuilder WithBillingAddress(Address address)
    {
        _billingAddress = address;
        return this;
    }

    public OrderBuilder WithShippingAddress(Address address)
    {
        _shippingAddress = address;
        return this;
    }

    public OrderBuilder WithOrderDate(DateTime date)
    {
        _orderDate = date;
        return this;
    }

    public OrderBuilder WithPaymentMethod(string method)
    {
        _paymentMethod = method;
        return this;
    }

    public OrderBuilder WithCurrency(string currency)
    {
        _currency = currency;
        return this;
    }

    public OrderBuilder WithSubTotal(decimal amount)
    {
        _subTotal = amount;
        return this;
    }

    public OrderBuilder WithDiscount(decimal amount)
    {
        _discountAmount = amount;
        return this;
    }

    public OrderBuilder WithTax(decimal amount)
    {
        _taxAmount = amount;
        return this;
    }

    public Invoice Build()
    {
        if (_invoiceId <= 0)
            throw new InvalidOperationException("Invoice ID is required.");

        if (string.IsNullOrWhiteSpace(_customerName))
            throw new InvalidOperationException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(_customerEmail))
            throw new InvalidOperationException("Customer email is required.");

        if (_billingAddress == null)
            throw new InvalidOperationException("Billing address is required.");

        if (_shippingAddress == null)
            throw new InvalidOperationException("Shipping address is required.");

        if (string.IsNullOrWhiteSpace(_paymentMethod))
            throw new InvalidOperationException("Payment method is required.");

        if (string.IsNullOrWhiteSpace(_currency))
            throw new InvalidOperationException("Currency is required.");

        decimal total =
            _subTotal
            - _discountAmount
            + _taxAmount;

        return new Invoice(
            _invoiceId,
            _customerName,
            _customerEmail!,
            _customerPhone ?? "",
            _billingAddress,
            _shippingAddress,
            _orderDate,
            _paymentMethod!,
            _currency!,
            _subTotal,
            _discountAmount,
            _taxAmount,
            total
        );
    }
}
