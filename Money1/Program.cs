using System;

class Money
{
    public int Cents { get; private set; }

    public Money(int cents)
    {
        Cents = cents;
    }

    public void SetMoney(int cents)
    {
        Cents = cents;
    }

    public void Display()
    {
        Console.WriteLine((Cents / 100) + "." + (Cents % 100).ToString("D2"));
    }
}

class PriceManager
{
    public static Money ReducePrice(Money price, int cents)
    {
        int totalCents = price.Cents - cents;
        if (totalCents < 0) totalCents = 0;
        return new Money(totalCents);
    }
}

class Product
{
    public string Name { get; private set; }
    public Money Price { get; private set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void ApplyDiscount(int cents)
    {
        Price = PriceManager.ReducePrice(Price, cents);
    }

    public void Display()
    {
        Console.Write(Name + ": ");
        Price.Display();
    }
}

class Program
{
    static void Main()
    {
        Money money = new Money(1050);
        Product product = new Product("Laptop", money);
        product.Display();
        product.ApplyDiscount(230);
        product.Display();
    }
}