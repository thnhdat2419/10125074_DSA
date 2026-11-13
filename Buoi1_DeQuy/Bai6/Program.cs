using System;
class UCLN
{
    public static int TimUCLN(int a, int b)
    {
        if (a % b == 0)
        {
            return b;
        }
        return TimUCLN(b, a % b);
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
        int ucln = UCLN.TimUCLN(a, b);
        Console.WriteLine("Uoc chung lon nhat cua {0} va {1} la: {2}", a, b, ucln);
    }
}