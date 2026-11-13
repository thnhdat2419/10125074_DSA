//Bai2
using System;
class TongBP
{
    public static int TinhTongBP(int a)
    {
        if (a == 1)
        {
            return 1;
        }
        return a * a + TinhTongBP(a - 1);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int tongBP = TongBP.TinhTongBP(n);
        Console.WriteLine("Tong binh phuong tu 1 den {0} la: {1}", n, tongBP);
    }
}
