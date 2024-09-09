using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');

            GreedyTimes greedyTimes = new GreedyTimes(capacity);
            greedyTimes.Packaging(input);
            greedyTimes.Print();

        }
    }
}

/*
150
Gold 28 Rubygem 16 USD 9 GBP 8
 */
