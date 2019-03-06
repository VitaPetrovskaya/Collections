using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class OrderItem
{
    public readonly int PartNumber;
    public readonly string Description;
    public readonly double UnitPrice;
    private int _quantity = 0;

    public OrderItem(int partNumber, string description, int quantity, double unitPrice)
    {
        this.PartNumber = partNumber;
        this.Description = description;
        this.Quantity = quantity;
        this.UnitPrice = unitPrice;
    }

    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity cannot be negative.");
            }

            _quantity = value;
        }
    }

    public override string ToString()
    {
        return String.Format("{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}",
            PartNumber, _quantity, Description, UnitPrice, UnitPrice * _quantity);
    }
}

public class Order
{
    private readonly List<OrderItem> _orderItems;

    public Order(List<OrderItem> orderItems)
    {
        this._orderItems = orderItems;
    }

    public OrderItem Find(Predicate<OrderItem> match)
    {
        return _orderItems.Find(match);
    }

    public void DisplayItems()
    {
        foreach (OrderItem item in _orderItems)
        {
            Console.WriteLine(item);
        }
    }
}


public class Program
{
    public static void Main()
    {
        var orderItems = new List<OrderItem>
        {
            new OrderItem(110072674, "Widget", 400, 45.17),
            new OrderItem(110072675, "Sprocket", 27, 5.3),
            new OrderItem(101030411, "Motor", 10, 237.5),
            new OrderItem(110072684, "Gear", 175, 5.17)
        };

        var order = new Order(orderItems);
        Display("Order #1", order);

        // TODO Replace with code that searches a list item in order.OrderItems. Use List<T> methods only.
        if (order.Find(x => x.PartNumber == 111033401) == null)
        {
            Console.WriteLine("Order #1 doesn't have #111033401 item.\n");
        }

        var newOrderItems = new List<OrderItem>(orderItems.Count + 2);
        newOrderItems.AddRange(orderItems);

        newOrderItems.Add( new OrderItem(111033401, "Nut", 10, .5));
        newOrderItems.Add( new OrderItem(127700026, "Crank", 27, 5.98));

        var newOrder = new Order(newOrderItems);
        Display("Order #2", newOrder);

        // TODO Replace with code that searches a list item in order.OrderItems. Use List<T> methods only.
        if (newOrder.Find(x => x.PartNumber == 127700026) != null)
        {
            Console.WriteLine("Order #2 has #127700026 item.");
        }

        Console.ReadLine();
    }

    private static void Display(string title, Order order)
    {
        Console.WriteLine(title);
        order.DisplayItems();
        Console.WriteLine();
    }
}