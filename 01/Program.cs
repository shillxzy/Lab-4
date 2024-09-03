class Point
{
    private int x, y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X()
    {
      return x; 
    }

    public int Y()
    {
        return y;
    }
}

class Rectangle
{
    private int topLeftX, topLeftY, bottomRightX, bottomRightY;

    public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
        this.bottomRightX = bottomRightX;
        this.bottomRightY = bottomRightY;
    }
    

    public bool Contains (Point point)
    {
        bool pointIN = false;
        if (topLeftX <= point.X() && point.X() <= bottomRightX
            && topLeftY <= point.Y() && point.Y() <= bottomRightY)
        {
            pointIN = true;
        }
        else
        {
            pointIN = false;
        }

        return pointIN;
         
    }
}

class Program
{
    static void Main()
    {

        // ------------------------------------------------- //

        string[] a = Console.ReadLine().Split(' ');
        int topLeftX = int.Parse(a[0]);
        int topLeftY = int.Parse(a[1]);
        int bottomRightX = int.Parse(a[2]);
        int bottomRightY = int.Parse(a[3]);

        Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

        // ------------------------------------------------- //
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            Point point = new Point(x, y);

            if (rectangle.Contains(point))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }


        // ------------------------------------------------- //


    }
}