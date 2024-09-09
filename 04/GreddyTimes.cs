using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Gold
    {
        public long GOLD;
        public Gold(long gOLD)
        {
            GOLD = gOLD;
        }

        public void Add(long amount)
        {
            GOLD += amount;
        }
    }

    class Gem
    {
        public long GEM;
        public Gem(long gOLD)
        {
            GEM = gOLD;
        }

        public void Add(long amount)
        {
            GEM += amount;
        }
    }

    class Cash
    {
        public long CASH;
        public Cash(long gOLD)
        {
            CASH = gOLD;
        }

        public void Add(long amount)
        {
            CASH += amount;
        }
    }
    internal class GreedyTimes
    {
        private long capacity;
        private Gold gold;
        private Gem gem;
        private Cash cash;

        public GreedyTimes(long capacity)
        {
            this.capacity = capacity;
            this.gold = new Gold(0);
            this.gem = new Gem(0);
            this.cash = new Cash(0);
        }

        public void Packaging(string[] input)
        {
            for (int i = 0; i < input.Length; i += 2)
            {
                string item = input[i];
                long value = long.Parse(input[i + 1]);

                if (capacity >= value)
                {
                    if (item == "Gold")
                    {
                        if (gold.GOLD + value <= capacity)
                        {
                            gold.Add(value);
                            capacity -= value;
                        }
                    }
                    else if (item.EndsWith("gem"))
                    {
                        if (gem.GEM + value <= gold.GOLD)
                        {
                            if (gem.GEM + value <= capacity)
                            {
                               gem.Add(value);
                                capacity -= value;
                            }
                        }
                    }
                    else if (item.Length == 3)
                    {
                        if (cash.CASH + value <= gem.GEM)
                        {
                            if (cash.CASH + value <= capacity)
                            {
                                cash.Add(value);
                                capacity -= value;
                            }
                        }
                    }
                }
            }
        }

        public void Print()
        {
            if (gold.GOLD > 0)
            {
                Console.WriteLine($"<Gold> ${gold.GOLD}");
                Console.WriteLine($"##gold - {gold.GOLD}");
            }
            if (gem.GEM > 0)
            {
                Console.WriteLine($"<Gem> ${gem.GEM}");
                Console.WriteLine($"##gem - {gem.GEM}");
            }
            if (cash.CASH > 0)
            {
                Console.WriteLine($"<Cash> ${cash.CASH}");
                Console.WriteLine($"##cash - {cash.CASH}");
            }
        }

    }
}
