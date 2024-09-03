using System;
class Program
{
    static void Main(string[] args)
    {
        long capacity = long.Parse(Console.ReadLine());
        long gold = 0, gems = 0, cash = 0;
        long goldInBag = 0, gemsInBag = 0, cashInBag = 0;

        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < input.Length; i += 2)
        {
            string item = input[i];
            long value = long.Parse(input[i + 1]);

            if (capacity >= value)
            {
                if (item == "Gold")
                {
                    if (goldInBag + value <= capacity)
                    {
                        gold += value;
                        goldInBag += value;
                        capacity -= value;
                    }
                }
                else if (item.EndsWith("gem"))
                {
                    if (gems + value <= gold)
                    {
                        if (gemsInBag + value <= capacity)
                        {
                            gems += value;
                            gemsInBag += value;
                            capacity -= value;
                        }
                    }
                }
                else if (item.Length == 3)
                {
                    if (cash + value <= gems)
                    {
                        if (cashInBag + value <= capacity)
                        {
                            cash += value;
                            cashInBag += value;
                            capacity -= value;
                        }
                    }
                }
            }
        }

        if (gold > 0)
        {
            Console.WriteLine($"<Gold> ${gold}");
            Console.WriteLine($"##gold - {gold}");
        }
        if (gems > 0)
        {
            Console.WriteLine($"<Gem> ${gems}");
            Console.WriteLine($"##gem - {gems}");
        }
        if (cash > 0)
        {
            Console.WriteLine($"<Cash> ${cash}");
            Console.WriteLine($"##cash - {cash}");
        }
    }
}


