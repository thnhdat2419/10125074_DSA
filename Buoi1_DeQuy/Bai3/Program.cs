//Bai3
using System;
class TongPhanN
{
    public static double TinhTongPhanN(int a)
    {
        if (a == 1)
        {
            return 1;
        }
        return (double)1 / a + TinhTongPhanN(a - 1);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double Tong1chiaN = TongPhanN.TinhTongPhanN(n);
        Console.WriteLine("Tong phan tu tu 1 den {0} la: {1}", n, Tong1chiaN);
    }
}