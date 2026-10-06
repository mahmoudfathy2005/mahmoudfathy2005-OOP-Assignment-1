# Critique of the Procedural Order System

## 1. Global Mutable Data

The program stores customers, products, orders and order lines in global variables and arrays.

For example, customer data is stored in separate global arrays such as customer IDs, customer names, customer emails, customer cities, and VIP status.

This is a problem because different functions can directly access and modify the same data. There is no clear owner for the data, which can make unintended changes easier to introduce.

A better design would keep the state inside objects such as Customer, Product, Order, and OrderLine.

## 2. Parallel Arrays

The program represents one customer using multiple arrays. The same index in each array represents the same customer.

For example, the customer ID, name, email, city, and VIP status at index 0 all belong to the same customer.

This makes the data harder to understand and maintain. If one array is changed incorrectly, the information can become inconsistent.

Using a Customer class would keep all customer-related information together in one object.

## 3. Data and Behavior Are Separated

The program stores its data in global arrays while operations on that data are implemented as separate functions.

For example, customer data is stored globally while functions such as adding and printing customers operate on that global state.

This makes it harder to understand which behavior belongs to which part of the system.

Using classes allows related state and behavior to be organized around the corresponding objects.

## 4. Lack of Encapsulation

The original program does not use classes or access modifiers to protect its important data.

Different functions can directly change global values such as product stock.

This makes it harder to guarantee that the data remains valid.

Encapsulation allows a class to control how its internal data is changed.

## 5. High Coupling

Some functions need to work with several different arrays and indexes at the same time.

For example, adding an order line requires knowledge of order data, product data, product stock, and order-line storage.

This creates strong dependencies between different parts of the program.

If the internal representation changes, many functions may need to be changed.

Using objects with clear responsibilities can reduce this coupling.

## 6. Index-Based Relationships

Orders and order lines use indexes to refer to customers and products.

This means that the relationships between objects depend on the internal array structure.

Using object references makes the relationships clearer. For example, an Order can directly reference a Customer and an OrderLine can directly reference a Product.

## Conclusion

The main design problem is that the program represents domain objects using global arrays and indexes instead of real objects.

The C# version should introduce Customer, Product, Order, and OrderLine classes. Each class should own the state and behavior that logically belongs to it.

The goal is to preserve the original functionality while improving the design using object-oriented programming.
