using System;

struct NhanVien
{
    public string MaNV;
    public string Hoten;
    public int Namsinh;
    public string Phongban;
    public int LuongCB;
    public int Thuong;
}

class Node
{
    public int Data;
    public Node Next;
    public Node(int d) { Data = d; Next = null; }
}

class VD
{
    static NhanVien[] DS;
    static Node pHead = null;

    static int NhapInt(string msg)
    {
        Console.Write(msg);
        return Convert.ToInt32(Console.ReadLine());
    }

    //BÀI 1
    static void Bai1()
    {
        int n = NhapInt("Nhap so phan tu cua mang: ");
        int[] a = new int[n];

        for (int i = 0; i < n; i++)
            a[i] = NhapInt("Nhap phan tu thu " + (i + 1) + ": ");

        Console.WriteLine("Cac phan tu cua mang la: ");
        for (int i = 0; i < n; i++)
            Console.Write(a[i] + " ");
        Console.WriteLine();

        int x = NhapInt("Nhap x: ");
        int k = NhapInt("Nhap vi tri k (0 den " + n + "): ");
        if (k < 0 || k > n) { Console.WriteLine("Vi tri khong hop le"); return; }

        int[] tmp = new int[a.Length + 1];
        for (int i = 0; i <= k - 1; i++) tmp[i] = a[i];
        tmp[k] = x;
        for (int i = k; i < a.Length; i++) tmp[i + 1] = a[i];
        a = tmp;

        Console.WriteLine("Mang sau khi chen: ");
        for (int i = 0; i < a.Length; i++)
            Console.Write(a[i] + " ");
        Console.WriteLine();
    }

    //BÀI 2
    static int thuclinh(int i)
    {
        return DS[i].LuongCB + DS[i].Thuong;
    }

    static void InNV(NhanVien nv)
    {
        Console.WriteLine("{0,-8}{1,-20}{2,-6}{3,-10}{4,-10}{5,-10}{6,-10}",
            nv.MaNV, nv.Hoten, nv.Namsinh, nv.Phongban,
            nv.LuongCB, nv.Thuong, nv.LuongCB + nv.Thuong);
    }

    static void Bai2()
    {
        int n = NhapInt("So nhan vien: ");
        DS = new NhanVien[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Nhan vien " + (i + 1));
            Console.Write("Ma NV: "); DS[i].MaNV = Console.ReadLine();
            Console.Write("Ho ten: "); DS[i].Hoten = Console.ReadLine();
            DS[i].Namsinh = NhapInt("Nam sinh: ");
            Console.Write("Phong ban: "); DS[i].Phongban = Console.ReadLine();
            DS[i].LuongCB = NhapInt("Luong CB: ");
            DS[i].Thuong = NhapInt("Thuong: ");
        }

        // a. Tổng thực lĩnh
        long tong = 0;
        for (int i = 0; i < n; i++) tong += thuclinh(i);
        Console.WriteLine("a. Tong thuc linh: " + tong);

        // b. Lương cơ bản thấp nhất
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
            if (min > DS[i].LuongCB) min = DS[i].LuongCB;
        Console.WriteLine("b. Nhan vien luong CB thap nhat (" + min + "):");
        for (int i = 0; i < n; i++)
            if (DS[i].LuongCB == min) InNV(DS[i]);

        // c. Đếm thưởng >= 1200000
        int dem = 0;
        for (int i = 0; i < n; i++)
            if (DS[i].Thuong >= 1200000) dem++;
        Console.WriteLine("c. So nhan vien thuong >= 1200000: " + dem);

        // d. Phòng ban tăng dần, trùng thì mã NV giảm dần
        for (int i = 0; i < n - 1; i++)
            for (int j = i + 1; j < n; j++)
            {
                int c = string.Compare(DS[i].Phongban, DS[j].Phongban);
                if (c > 0 || (c == 0 && string.Compare(DS[i].MaNV, DS[j].MaNV) < 0))
                {
                    NhanVien t = DS[i]; DS[i] = DS[j]; DS[j] = t;
                }
            }
        Console.WriteLine("d. Danh sach sau khi sap xep:");
        for (int i = 0; i < n; i++) InNV(DS[i]);

        // e. Tăng lương 5%
        for (int i = 0; i < n; i++)
            DS[i].LuongCB = (int)(DS[i].LuongCB * 1.05);
        Console.WriteLine("e. Sau khi tang luong 5%:");
        for (int i = 0; i < n; i++) InNV(DS[i]);
    }

    //BÀI 3
    static long TongMaTran(int[,] a, int n)
    {
        long t = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) t += a[i, j];
        return t;
    }

    static int DuongNhoNhat(int[,] a, int n)
    {
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (a[i, j] > 0 && a[i, j] < min) min = a[i, j];
        return min;
    }

    static long TongCheoPhu(int[,] a, int n)
    {
        long t = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (j == (n - 1) - i) t += a[i, j];
        return t;
    }

    static bool CheoChinhTangDan(int[,] a, int n)
    {
        int[] tg = new int[n];
        for (int i = 0; i < n; i++) tg[i] = a[i, i];
        for (int i = 0; i <= n - 2; i++)
            for (int j = i + 1; j <= n - 1; j++)
                if (tg[i] >= tg[j]) return false;
        return true;
    }

    static void Bai3()
    {
        int n = NhapInt("Nhap n (0 <= n < 100): ");
        int[,] a = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                a[i, j] = NhapInt("a[" + i + "," + j + "] = ");

        Console.WriteLine("a. Tong tat ca phan tu: " + TongMaTran(a, n));
        int m = DuongNhoNhat(a, n);
        Console.WriteLine("b. Duong nho nhat: " + (m == int.MaxValue ? "khong co" : m.ToString()));
        Console.WriteLine("c. Tong duong cheo phu: " + TongCheoPhu(a, n));
        Console.WriteLine("d. Duong cheo chinh tang dan: " + CheoChinhTangDan(a, n));
    }
    static void NhapDS()
    {
        pHead = null;
        int n = NhapInt("So phan tu cua danh sach: ");
        Node cuoi = null;
        for (int i = 0; i < n; i++)
        {
            Node p = new Node(NhapInt("Phan tu thu " + (i + 1) + ": "));
            if (pHead == null) pHead = p; else cuoi.Next = p;
            cuoi = p;
        }
    }

    static void InDS()
    {
        for (Node p = pHead; p != null; p = p.Next)
            Console.Write(p.Data + " ");
        Console.WriteLine();
    }

    static int DuongNhoNhatDS()
    {
        int minduong = int.MaxValue;
        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data > 0 && p.Data < minduong) minduong = p.Data;
        return minduong;
    }

    //BÀI 4
    static int DemX(int x)
    {
        int d = 0;
        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data == x) d = d + 1;
        return d;
    }

    static void XoaXDau(int x)
    {
        Node p = pHead, t = null;          
        while (p != null && p.Data != x)
        {
            t = p;
            p = p.Next;
        }
        if (p == null) return;            
        if (p == pHead) pHead = pHead.Next; 
        else t.Next = p.Next;                
    }

    static void Bai4()
    {
        NhapDS();
        int x = NhapInt("Nhap x: ");
        Console.WriteLine("a. So phan tu bang x: " + DemX(x));
        int m = DuongNhoNhatDS();
        Console.WriteLine("b. Duong nho nhat: " + (m == int.MaxValue ? "khong co" : m.ToString()));
        XoaXDau(x);
        Console.Write("c. Danh sach sau khi xoa x dau tien: ");
        InDS();
    }

    //BÀI 5
    static bool KTNT(int x)
    {
        if (x < 2) return false;
        for (int i = 2; i * i <= x; i++)
            if (x % i == 0) return false;
        return true;
    }

    static void Bai5()
    {
        NhapDS();

        // a. Lớn nhất
        int max = int.MinValue;
        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data > max) max = p.Data;
        Console.WriteLine("a. Phan tu lon nhat: " + (pHead == null ? "danh sach rong" : max.ToString()));

        // b. Tổng
        long t = 0;
        for (Node p = pHead; p != null; p = p.Next) t += p.Data;
        Console.WriteLine("b. Tong: " + t);

        // c. Đếm số nguyên tố
        int dem = 0;
        for (Node p = pHead; p != null; p = p.Next)
            if (KTNT(p.Data)) dem++;
        Console.WriteLine("c. So nguyen to: " + dem);

        // d. Đếm âm, 0, dương
        int am = 0, khong = 0, duong = 0;
        for (Node p = pHead; p != null; p = p.Next)
        {
            if (p.Data < 0) am++;
            else if (p.Data > 0) duong++;
            else khong++;
        }
        Console.WriteLine("d. Am: " + am + ", bang 0: " + khong + ", duong: " + duong);

        // e. Đếm phần tử bằng x
        int x = NhapInt("Nhap x: ");
        int demX = 0;
        for (Node p = pHead; p != null; p = p.Next)
            if (p.Data == x) demX++;
        Console.WriteLine("e. So phan tu bang x: " + demX);

        // f. Dương nhỏ nhất
        int m = DuongNhoNhatDS();
        Console.WriteLine("f. Duong nho nhat: " + (m == int.MaxValue ? "khong co" : m.ToString()));
    }
    static void Bai7()
    {
        int x = NhapInt("Nhap so ngay: ");
        int[] a = new int[x];
        for (int i = 0; i < x; i++)
            a[i] = NhapInt("Nhap nhiet do ngay " + (i + 1) + ": ");
        int max = a[0];
        int ViTri = 0;
        for (int i = 1; i < x; i++)
            if (a[i] > max)
            {
                max = a[i];
                ViTri = i;
            }
        Console.WriteLine("Nhiet do cao nhat: " + max);
        int min = a[0];
        int ViTrimin = 0;
        for (int i = 1; i < x; i++)
            if (a[i] < min)
            { 
                min= a[i];
                ViTrimin = i;
            }
        Console.WriteLine("Nhiet do thap nhat:" + min);
        double tong = 0;
        


    }

    //MAIN: chạy cả
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
