//Bai1
using System;
class Tong
{
    public static int TinhTong(int a)
    {
        if (a == 1)
        {
            return 1;
        }
        return a + TinhTong(a - 1);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int tong = Tong.TinhTong(n);
        Console.WriteLine("Tong tu 1 den {0} la: {1}", n, tong);
    }
}