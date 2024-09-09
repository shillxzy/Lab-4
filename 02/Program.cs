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

        total *= (int)season;

        float discountAmount = 0;
        if (discount == Discount.VIP)
        {
            discountAmount = (total * (int)Discount.VIP) / 100;
        }
        else if (discount == Discount.SecondVisit)
        {
            discountAmount = (total * (int)Discount.SecondVisit) / 100;
        }

        total -= discountAmount;


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

        string discounts = discount.ToString();
        if (input.Length > 3)
        {
            discounts = input[3];
        }

        PriceCalculator.Season SEAS = Enum.Parse<PriceCalculator.Season>(seasons);
        PriceCalculator.Discount DIS = Enum.Parse<PriceCalculator.Discount>(discounts);


        PriceCalculator calculator = new PriceCalculator(pricePerDay, numberOfDays, SEAS, DIS);

        float total = 0.0f;
        total = calculator.TotalCostofVacation();

   
        double result = Math.Round(total, 2);

        Console.WriteLine(result);
    }
}

// 50,25 5 Summer VIP
// 120,20 2 Winter