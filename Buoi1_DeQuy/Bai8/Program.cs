using System;
class Can
{
    public static double TongCan(int n, int a)
    {
        if (n == a)
        {
            return Math.Sqrt(n);
        }
        return Math.Sqrt(n + TongCan(n + 1, a));
    }
    public static double S(int n)
    {
        return TongCan(1, n);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap so nguyen duong a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        double Tong = Can.TongCan(n, a);
        Console.WriteLine($"Tong can bac 2 tu {n} den {a} la: {Tong}");

    }
}