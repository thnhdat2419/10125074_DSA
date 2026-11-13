using System;
class LuyThua
{
    public static int TinhLuyThua(int a, int b)
    {
        if (b == 0)
        {
            return 1;
        }
        return a * TinhLuyThua(a, b - 1);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap so nguyen duong b: ");
        int b = Convert.ToInt32(Console.ReadLine());
        int luyThua = LuyThua.TinhLuyThua(a, b);
        Console.WriteLine("Luy thua cua {0} mu {1} la: {2}", a, b, luyThua);
    }
}