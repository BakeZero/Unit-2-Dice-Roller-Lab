using System;

class Program
{
    static void Main()
    {
        string prompt = "y";
        int roll = 1;
        Console.WriteLine("Welcome to the Grand Circus Casino!");
        Console.Write("How many sides should each die have? (Only 6-sided is supported): ");
        int sides = int.Parse(Console.ReadLine());

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

            Console.Write("Roll again? (y/n): ");
            prompt = Console.ReadLine();
            Console.WriteLine();
        } while (prompt == "y");
        Console.WriteLine("Thanks for playing!");
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
