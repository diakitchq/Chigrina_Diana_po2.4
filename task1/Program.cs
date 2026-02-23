using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter coffee name: ");
        string coffeeName = Console.ReadLine();

        Console.Write("Enter price per cup: ");
        double pricePerCup = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number of cups: ");
        int numberOfCups = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter sugar portions: ");
        int sugarPortions = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter extra topping price: ");
        double extraToppingPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter first letter of size: ");
        char sizeFirstLetter = Convert.ToChar(Console.ReadLine());

        Console.Write("Is takeaway (true/false): ");
        bool isTakeaway = Convert.ToBoolean(Console.ReadLine());

        double coffeeCost = pricePerCup * numberOfCups;
        double sugarCost = sugarPortions * 0.2;
        double totalOrderPrice = coffeeCost + sugarCost + extraToppingPrice;

        if (isTakeaway)
        {
            totalOrderPrice += totalOrderPrice * 0.10;
        }

        Console.WriteLine("\nCOFFEE ORDER DETAILS");
        Console.WriteLine($"Coffee Name: {coffeeName}");
        Console.WriteLine($"Price per Cup: {pricePerCup}");
        Console.WriteLine($"Number of Cups: {numberOfCups}");
        Console.WriteLine($"Sugar Portions: {sugarPortions}");
        Console.WriteLine($"Extra Topping Price: {extraToppingPrice}");
        Console.WriteLine($"Size: {sizeFirstLetter}");
        Console.WriteLine($"Is Takeaway: {isTakeaway}");
        Console.WriteLine($"Coffee Cost: {coffeeCost}");
        Console.WriteLine($"Sugar Cost: {sugarCost}");
        Console.WriteLine($"Total Order Price: {totalOrderPrice}");

        Console.ReadKey();
    }
}



