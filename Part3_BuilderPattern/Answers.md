# Builder Pattern Answers

## Task 3.1

### 1. Why is a single 20-parameter constructor a problem?

A constructor with around 20 parameters is difficult to read and easy to misuse.

When many parameters have the same type, such as strings or decimal values, it is possible to pass two values in the wrong order and still compile successfully.

It also becomes difficult to remember which parameter belongs to which property.

If another optional property is added later, the constructor becomes even harder to use and every call site may need to be updated.

A builder makes the construction process more readable because each value is given through a clearly named method.

### 2. Is it only a long-constructor problem?

No. There is also a deeper design issue.

The invoice contains several groups of related information, such as billing address, shipping address, and order/payment information.

Putting all of these unrelated responsibilities into one construction process makes the code harder to understand and maintain.

Separating these concepts allows each part to have a clearer responsibility.

## Task 3.3

The composed version is better because each builder has a smaller and clearer responsibility.

AddressBuilder is responsible for constructing and validating an Address.

OrderBuilder is responsible for the invoice and order/payment information.

AddressBuilder can validate address-related fields independently without making the main builder responsible for every address rule.

The same AddressBuilder can also be reused for both the billing and shipping addresses, so the address construction logic does not have to be duplicated.

The final construction code is also easier to read because the different groups of information are separated.

Overall, the composed builder follows single responsibility better, improves reuse, and makes the construction process easier to understand.
