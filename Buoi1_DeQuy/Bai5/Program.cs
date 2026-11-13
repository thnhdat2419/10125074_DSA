using System;
class UocLeMax
{
    public static int TimUocLeMax(int n)
    {
        if (n % 2 != 0)
        {
            return n;
        }
        return TimUocLeMax(n / 2);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so nguyen duong n: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int uocLeMax = UocLeMax.TimUocLeMax(n);
        Console.WriteLine("Uoc le lon nhat cua {0} la: {1}", n, uocLeMax);
    }
}