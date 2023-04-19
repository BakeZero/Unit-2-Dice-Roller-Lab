using System;

class Program
{
    static void Main()
    {
        int roll = 1;
        Console.WriteLine("Welcome to the Grand Circus Casino!");
        Console.WriteLine("How many sides should each die have? (2-144)");
        int sides = 0;
        Validator.GetNumber(ref sides);

        do
        {
            int die1 = GenerateRandom(sides);
            int die2 = GenerateRandom(sides);
            Console.WriteLine($"Roll {roll++}:");
            Console.WriteLine($"You rolled a {die1} and a {die2} ({die1 + die2} total)");

            if (sides == 6)
            {
                Console.WriteLine($"{SixSidedFaces(die1, die2)}");
                SixSidedTotals(die1 + die2);
            }
        } while (Continue());
        Console.WriteLine("Thanks for playing!");
    }

    static bool Continue()
    {
        Console.Write("Continue? (y/n): ");
        string prompt = Console.ReadLine();
        if (prompt.ToLower() == "y")
            return true;
        else if (prompt.ToLower() == "n")
            return false;
        else
            return Continue();
    }

    static int GenerateRandom( int sides)
    {
        Random r = new Random();
        return r.Next( 1, sides+1 );
    }

    static string SixSidedFaces(int die1, int die2)
    {
        if (die1 == 1 && die2 == 1)
            return "Snake Eyes";
        else if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1))
            return "Ace Deuce";
        else if (die1 == 6 && die2 == 6)
            return "Box Cars";
        else    
            return "";
    }

    static void SixSidedTotals(int total)
    {
        if (total == 7 || total == 11)
            Console.WriteLine("Win");
        else if (total == 2 || total == 3 || total == 12)
            Console.WriteLine("Craps!");
    }
}


public static class Validator
{
    /* Method to accept only a valid input */
    public static void GetNumber(ref int rad)
    {
        try
        {
            Console.Write("Enter a number: ");
            rad = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input.");
            GetNumber(ref rad);
        }
        if (rad < 2)
        {
            Console.WriteLine("Too few sides!");
            GetNumber(ref rad);
        }
        else if (rad > 144)
        {
            Console.WriteLine("Too many sides... That's just a ball!");
            GetNumber(ref rad);
        }
        return;
    }
}