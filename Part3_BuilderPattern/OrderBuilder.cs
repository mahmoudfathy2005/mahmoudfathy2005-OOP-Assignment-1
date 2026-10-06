using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern;

public class OrderBuilder
{
    private DateTime _orderDate;
    private string? _paymentMethod;
    private string? _currency;

    private decimal _subTotal;
    private decimal _discountAmount;
    private decimal _taxAmount;
    private decimal _totalAmount;

    public OrderBuilder WithOrderDate(DateTime value)
    {
        _orderDate = value;
        return this;
    }

    public OrderBuilder WithPaymentMethod(string value)
    {
        _paymentMethod = value;
        return this;
    }

    public OrderBuilder WithCurrency(string value)
    {
        _currency = value;
        return this;
    }

    public OrderBuilder WithSubTotal(decimal value)
    {
        _subTotal = value;
        return this;
    }

    public OrderBuilder WithDiscountAmount(decimal value)
    {
        _discountAmount = value;
        return this;
    }

    public OrderBuilder WithTaxAmount(decimal value)
    {
        _taxAmount = value;
        return this;
    }

    public OrderBuilder WithTotalAmount(decimal value)
    {
        _totalAmount = value;
        return this;
    }

    public Order Build()
    {
        if (_orderDate == default)
            throw new InvalidOperationException("OrderDate is required.");

        if (string.IsNullOrWhiteSpace(_currency))
            throw new InvalidOperationException("Currency is required.");

        if (_subTotal < 0)
            throw new InvalidOperationException("SubTotal cannot be negative.");

        if (_discountAmount < 0)
            throw new InvalidOperationException("DiscountAmount cannot be negative.");

        if (_taxAmount < 0)
            throw new InvalidOperationException("TaxAmount cannot be negative.");

        if (_totalAmount < 0)
            throw new InvalidOperationException("TotalAmount cannot be negative.");

        return new Order(
            _orderDate,
            _paymentMethod ?? "",
            _currency,
            _subTotal,
            _discountAmount,
            _taxAmount,
            _totalAmount
        );
    }
}
