//Bai7
using System;
class SoChuSo
{
    public static int DemSoChuSo(int a)
    {
        if (a == 0)
        {
            return 0;
        }
        return DemSoChuSo(a / 10) + 1;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        int dem = SoChuSo.DemSoChuSo(a);
        Console.WriteLine("Số chữ số của {0} là {1}", a, dem);
    }
}