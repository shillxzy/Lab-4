using System.Net;
using System.Runtime.CompilerServices;
using static PriceCalculator;

class PriceCalculator
{
    private float pricePerDay;
    private int numberOfDays;
    private Season season;
    private Discount discount;

    public enum Season
    {
        Spring = 2,
        Summer = 4,
        Autumn = 1,
        Winter = 3
    }

    public enum Discount
    {
        VIP = 20,
        SecondVisit = 10,
        None = 0
    }


    public PriceCalculator (float pricePerDay, int numberOfDays, Season season, Discount discount)
    {
        this.pricePerDay = pricePerDay;
        this.numberOfDays = numberOfDays;
        this.season = season;
        this.discount = discount;
    }

    public float TotalCostofVacation()
    {
        float total = 0;

        total = pricePerDay * numberOfDays;

        return total;
    }
}

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        float pricePerDay = float.Parse(input[0]);
        int numberOfDays = int.Parse(input[1]);
        string seasons = input[2];
        float discount = 0;

        PriceCalculator.Season SEAS = Enum.Parse<PriceCalculator.Season>(seasons);
        PriceCalculator.Discount DIS = (PriceCalculator.Discount)discount;


        PriceCalculator calculator = new PriceCalculator(pricePerDay, numberOfDays, SEAS, DIS);

        float total = 0.0f;
        total = calculator.TotalCostofVacation();

        if (SEAS == Season.Summer)
        {
            total *= (int)Season.Summer;
        }
        else if (SEAS == Season.Spring)
        {
            total *= (int)Season.Spring;
        }
        else if (SEAS == Season.Autumn)
        {
            total *= (int)Season.Autumn;
        }
        else if (SEAS == Season.Winter)
        {
            total *= (int)Season.Winter;
        }

        if (DIS == Discount.VIP)
        {
            discount = ((int)Discount.VIP / 100) * total;
            total = discount;
        }
        else if (DIS == Discount.SecondVisit)
        {
            discount = ((int)Discount.SecondVisit / 100) * total;
            total = discount;
        }

        double result = Math.Round(total, 2);

        Console.WriteLine(result);
    }
}

// 50,25 5 Summer VIP
// 120,20 2 Winter