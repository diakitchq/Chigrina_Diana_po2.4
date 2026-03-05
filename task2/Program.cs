using System;

class Program
{
    static void Main()
    {
        // Exercise 1
        Console.WriteLine("Exercise 1:");
        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        if (a == b)
            Console.WriteLine("The numbers are equal");
        else if (a > b)
            Console.WriteLine("The first number is greater");
        else
            Console.WriteLine("The first number is less");

        Console.WriteLine();


        // Exercise 2
        Console.WriteLine("Exercise 2:");
        Console.Write("Enter number: ");
        double n = Convert.ToDouble(Console.ReadLine());

        if (n > 5 && n < 10)
            Console.WriteLine("The number is greater than 5 and less than 10");
        else
            Console.WriteLine("Unknown number");

        Console.WriteLine();


        // Exercise 3
        Console.WriteLine("Exercise 3:");
        Console.Write("Enter number: ");
        n = Convert.ToDouble(Console.ReadLine());

        if (n == 5 || n == 10)
            Console.WriteLine("The number is either 5 or 10");
        else
            Console.WriteLine("Unknown number");

        Console.WriteLine();


        // Exercise 4
        Console.WriteLine("Exercise 4:");
        Console.Write("Enter deposit amount: ");
        double d = Convert.ToDouble(Console.ReadLine());

        if (d < 100)
            d = d + d * 0.05;
        else if (d <= 200)
            d = d + d * 0.07;
        else
            d = d + d * 0.10;

        Console.WriteLine("Final amount: " + d);

        Console.WriteLine();


        // Exercise 5
        Console.WriteLine("Exercise 5:");
        Console.Write("Enter deposit amount: ");
        d = Convert.ToDouble(Console.ReadLine());

        if (d < 100)
            d = d + d * 0.05;
        else if (d <= 200)
            d = d + d * 0.07;
        else
            d = d + d * 0.10;

        d = d + 15; // bonus

        Console.WriteLine("Final amount with bonus: " + d);

        Console.WriteLine();


        // Exercise 6
        Console.WriteLine("Exercise 6:");
        Console.WriteLine("Enter operation number:");
        Console.WriteLine("1.Addition");
        Console.WriteLine("2.Subtraction");
        Console.WriteLine("3.Multiplication");

        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
            case 1:
                Console.WriteLine("Addition");
                break;

            case 2:
                Console.WriteLine("Subtraction");
                break;

            case 3:
                Console.WriteLine("Multiplication");
                break;

            default:
                Console.WriteLine("Operation is undefined");
                break;
        }

        Console.WriteLine();


        // Exercise 7
        Console.WriteLine("Exercise 7:");
        Console.WriteLine("Enter operation number:");
        Console.WriteLine("1.Addition");
        Console.WriteLine("2.Subtraction");
        Console.WriteLine("3.Multiplication");

        op = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter first number: ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        b = Convert.ToDouble(Console.ReadLine());

        switch (op)
        {
            case 1:
                Console.WriteLine("Result: " + (a + b));
                break;

            case 2:
                Console.WriteLine("Result: " + (a - b));
                break;

            case 3:
                Console.WriteLine("Result: " + (a * b));
                break;

            default:
                Console.WriteLine("Operation is undefined");
                break;
        }
    }
}

