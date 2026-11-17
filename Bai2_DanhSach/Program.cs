
using System;

// KHAI BAO NHAN VIEN
struct NhanVien
{
    public string MaNV;
    public string Hoten;
    public int Namsinh;
    public string Phongban;
    public int LuongCB;
    public int Thuong;
}

// KHAI BAO NODE
class Node
{
    public int Data;
    public Node Next;

    public Node(int d)
    {
        Data = d;
        Next = null;
    }
}

class VD
{
    static NhanVien[] DS;
    static Node pHead = null;

    // BAI 1
    static void Bai1()
    {
        Console.Write("Nhap so phan tu: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap a[" + i + "]: ");
            a[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Mang ban dau:");
        for (int i = 0; i < n; i++)
            Console.Write(a[i] + " ");

        Console.Write("\nNhap x: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nhap vi tri chen: ");
        int k = Convert.ToInt32(Console.ReadLine());

        if (k < 0 || k > n)
        {
            Console.WriteLine("Vi tri khong hop le");
            return;
        }

        int[] b = new int[n + 1];

        for (int i = 0; i < k; i++)
            b[i] = a[i];

        b[k] = x;

        for (int i = k; i < n; i++)
            b[i + 1] = a[i];

        Console.WriteLine("Mang sau khi chen:");
        for (int i = 0; i < n + 1; i++)
            Console.Write(b[i] + " ");

        Console.WriteLine();
    }


    // BAI 2
    static int Thuclinh(int i)
    {
        return DS[i].LuongCB + DS[i].Thuong;
    }

    static void InNV(NhanVien nv)
    {
        Console.WriteLine(nv.MaNV + " " + nv.Hoten + " " +
            nv.Namsinh + " " + nv.Phongban + " " +
            nv.LuongCB + " " + nv.Thuong);
    }

    static void Bai2()
    {
        Console.Write("Nhap so nhan vien: ");
        int n = Convert.ToInt32(Console.ReadLine());

        DS = new NhanVien[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhan vien " + (i + 1));

            Console.Write("Ma NV: ");
            DS[i].MaNV = Console.ReadLine();

            Console.Write("Ho ten: ");
            DS[i].Hoten = Console.ReadLine();

            Console.Write("Nam sinh: ");
            DS[i].Namsinh = Convert.ToInt32(Console.ReadLine());

            Console.Write("Phong ban: ");
            DS[i].Phongban = Console.ReadLine();

            Console.Write("Luong co ban: ");
            DS[i].LuongCB = Convert.ToInt32(Console.ReadLine());

            Console.Write("Thuong: ");
            DS[i].Thuong = Convert.ToInt32(Console.ReadLine());
        }

        // a. Tong thuc linh
        int tong = 0;

        for (int i = 0; i < n; i++)
            tong += Thuclinh(i);

        Console.WriteLine("Tong thuc linh: " + tong);

        // b. Luong co ban thap nhat
        int min = DS[0].LuongCB;

        for (int i = 1; i < n; i++)
            if (DS[i].LuongCB < min)
                min = DS[i].LuongCB;

        Console.WriteLine("Nhan vien luong thap nhat:");

        for (int i = 0; i < n; i++)
            if (DS[i].LuongCB == min)
                InNV(DS[i]);

        // c. Dem nhan vien co thuong >= 1200000
        int dem = 0;

        for (int i = 0; i < n; i++)
            if (DS[i].Thuong >= 1200000)
                dem++;

        Console.WriteLine("So nhan vien: " + dem);

        // d. Sap xep phong ban tang dan, ma NV giam dan
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int c = string.Compare(DS[i].Phongban, DS[j].Phongban);

                if (c > 0 || (c == 0 &&
                    string.Compare(DS[i].MaNV, DS[j].MaNV) < 0))
                {
                    NhanVien t = DS[i];
                    DS[i] = DS[j];
                    DS[j] = t;
                }
            }
        }

        Console.WriteLine("Danh sach sau sap xep:");

        for (int i = 0; i < n; i++)
            InNV(DS[i]);

        // e. Tang luong 5%
        for (int i = 0; i < n; i++)
            DS[i].LuongCB = (int)(DS[i].LuongCB * 1.05);

        Console.WriteLine("Danh sach sau tang luong:");

        for (int i = 0; i < n; i++)
            InNV(DS[i]);
    }


    // BAI 3
    static void Bai3()
    {
        Console.Write("Nhap n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] a = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("a[" + i + "," + j + "] = ");
                a[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // a. Tong ma tran
        int tong = 0;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                tong += a[i, j];

        Console.WriteLine("Tong ma tran: " + tong);

        // b. So duong nho nhat
        int min = int.MaxValue;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (a[i, j] > 0 && a[i, j] < min)
                    min = a[i, j];

        if (min == int.MaxValue)
            Console.WriteLine("Khong co so duong");
        else
            Console.WriteLine("So duong nho nhat: " + min);

        // c. Tong duong cheo phu
        tong = 0;

        for (int i = 0; i < n; i++)
            tong += a[i, n - 1 - i];

        Console.WriteLine("Tong cheo phu: " + tong);

        // d. Kiem tra cheo chinh tang dan
        bool tang = true;

        for (int i = 0; i < n - 1; i++)
            if (a[i, i] >= a[i + 1, i + 1])
                tang = false;

        Console.WriteLine("Cheo chinh tang dan: " + tang);
    }


    // NHAP DANH SACH LIEN KET
    static void NhapDS()
    {
        pHead = null;

        Console.Write("Nhap so phan tu: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Node cuoi = null;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap phan tu: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Node p = new Node(x);

            if (pHead == null)
                pHead = p;
            else
                cuoi.Next = p;

            cuoi = p;
        }
    }


    // IN DANH SACH
    static void InDS()
    {
        Node p = pHead;

        while (p != null)
        {
            Console.Write(p.Data + " ");
            p = p.Next;
        }

        Console.WriteLine();
    }


    // TIM SO DUONG NHO NHAT
    static int DuongNhoNhatDS()
    {
        int min = int.MaxValue;

        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data > 0 && p.Data < min)
                min = p.Data;

        return min;
    }


    // BAI 4
    static void Bai4()
    {
        NhapDS();

        Console.Write("Nhap x: ");
        int x = Convert.ToInt32(Console.ReadLine());

        // a. Dem so phan tu bang x
        int dem = 0;

        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data == x)
                dem++;

        Console.WriteLine("So phan tu bang x: " + dem);

        // b. So duong nho nhat
        int min = DuongNhoNhatDS();

        if (min == int.MaxValue)
            Console.WriteLine("Khong co so duong");
        else
            Console.WriteLine("So duong nho nhat: " + min);

        // c. Xoa x dau tien
        Node p = pHead;
        Node truoc = null;

        while (p != null && p.Data != x)
        {
            truoc = p;
            p = p.Next;
        }

        if (p != null)
        {
            if (truoc == null)
                pHead = p.Next;
            else
                truoc.Next = p.Next;
        }

        Console.WriteLine("Danh sach sau khi xoa:");
        InDS();
    }


    // KIEM TRA SO NGUYEN TO
    static bool KTNT(int x)
    {
        if (x < 2)
            return false;

        for (int i = 2; i * i <= x; i++)
            if (x % i == 0)
                return false;

        return true;
    }


    // BAI 5
    static void Bai5()
    {
        NhapDS();

        int max = int.MinValue;
        int tong = 0;
        int demNT = 0;
        int am = 0, khong = 0, duong = 0;

        Console.Write("Nhap x: ");
        int x = Convert.ToInt32(Console.ReadLine());

        int demX = 0;

        for (Node p = pHead; p != null; p = p.Next)
        {
            if (p.Data > max)
                max = p.Data;

            tong += p.Data;

            if (KTNT(p.Data))
                demNT++;

            if (p.Data < 0)
                am++;
            else if (p.Data == 0)
                khong++;
            else
                duong++;

            if (p.Data == x)
                demX++;
        }

        if (pHead == null)
            Console.WriteLine("Danh sach rong");
        else
            Console.WriteLine("Phan tu lon nhat: " + max);

        Console.WriteLine("Tong: " + tong);
        Console.WriteLine("So nguyen to: " + demNT);
        Console.WriteLine("So am: " + am);
        Console.WriteLine("So 0: " + khong);
        Console.WriteLine("So duong: " + duong);
        Console.WriteLine("So phan tu bang x: " + demX);

        int min = DuongNhoNhatDS();

        if (min == int.MaxValue)
            Console.WriteLine("Khong co so duong");
        else
            Console.WriteLine("So duong nho nhat: " + min);
    }


    // BAI 7
    static void Bai7()
    {
        Console.Write("Nhap so ngay: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0)
            return;

        int[] a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap nhiet do ngay " + (i + 1) + ": ");
            a[i] = Convert.ToInt32(Console.ReadLine());
        }

        int max = a[0];
        int min = a[0];
        int vtMax = 0;
        int vtMin = 0;
        double tong = 0;

        for (int i = 0; i < n; i++)
        {
            if (a[i] > max)
            {
                max = a[i];
                vtMax = i;
            }

            if (a[i] < min)
            {
                min = a[i];
                vtMin = i;
            }

            tong += a[i];
        }

        Console.WriteLine("Nhiet do cao nhat: " + max);
        Console.WriteLine("Ngay: " + (vtMax + 1));

        Console.WriteLine("Nhiet do thap nhat: " + min);
        Console.WriteLine("Ngay: " + (vtMin + 1));

        Console.WriteLine("Nhiet do trung binh: " + tong / n);
    }


    // MAIN
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("BAI 1");
        Bai1();

        Console.WriteLine("\nBAI 2");
        Bai2();

        Console.WriteLine("\nBAI 3");
        Bai3();

        Console.WriteLine("\nBAI 4");
        Bai4();

        Console.WriteLine("\nBAI 5");
        Bai5();

        Console.WriteLine("\nBAI 7");
        Bai7();

        Console.ReadKey();
    }
}
