using System;
using DXP.QA.Vile.Newbie.Vile.Day001.DataType;
using DXP.QA.Vile.Newbie.Vile.Day002.Static;
using DXP.QA.Vile.Newbie.Vile.Day003.Variable;
using DXP.QA.Vile.Newbie.Vile.Day005.Loop;
using DXP.QA.Vile.Newbie.Vile.Common;

namespace Vile
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //DAY 001:
            //data type Int, string, bool
            var day1 = new DataType();
            day1.printInfo();
            // DAY 002:
            // Static
            SecondClass secondclass = new SecondClass();
            secondclass.printInfo();
            
            // DAY 003:
            // Variable, sử dụng $
            //Cách cũ
            // GiangVien giangvien = new GiangVien(111, "Viet Le", "165 Thai Ha", "Toan", "Hinh Giai Tich"); 
            //Cách mới
            var giangVien = new GiangVien(111, "Viet Le", "165 Thai Ha", "Toan", "Dai so gia tu", "Emond LAngte");
            giangVien.printInfo();
            // Phân biệt public vs private: ở GiangVien khai báo là private thì ở đây tịt ko refer được
            //Console.WriteLine(giangVien.khoa); ==> lỗi vì field khoa là private
            Console.WriteLine(giangVien.test); // ==> OK vì test field là public

            //Day004: naming convention

            //DAY005: IF WHILE FOR LIST ARRAY
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++ Begin day 005 ++++++++++++++++++++++++++++++++++++++");
            // Constructor
            var sumList = new SumList();
            Console.WriteLine("Using constructor:");
            sumList.printInfo();
            //List<int> numbers = new List<int>() { 1, 3, 7, 8, 11, 2, 40, 51 };
            // Khoi tao object ngoai constructor
            SumList.daySo = new List<int>() { 1, 3, 7, 8, 11, 2, 40, 51 };
            //sumList = new SumList();
            //sumList.printInfo(numbers);
            sumList.printInfo();
            //Console.WriteLine($"Tinh Tong cac phan tu le (su dung for + if clause): {sumList.sumUsingForAndIf(numbers)}");
            //Console.WriteLine($"Tinh Tong cac phan tu le (su dung foreach + if clause): {sumList.sumUsingForeachAndIf(numbers)}");
            //Console.WriteLine($"Tinh Tong cac phan tu le (su dung while + if clause): {sumList.sumUsingWhileAndIf(numbers)}");
            //Console.WriteLine($"Tinh Tong cac phan tu le (su dung while + while ): {sumList.sumUsingWhileAndWhile(numbers)}");

            //constructor
            var sumArray = new SumArray();
            Console.WriteLine("Using constructor:");
            sumArray.printInfo();
            //using Polymorphism
            Console.WriteLine("Using Polymorphism:");
            SumArray.printInforUsingPolymorphism();

            //Khoi tao object static
            SumArray.daySo = new int[] { 1, 2, 3, 4, 5, 6, 21, 30 };
            //sumArray = new SumArray();
            sumArray.printInfo();


            //var daySo = new int[] {1, 2, 3, 4, 5, 6, 21, 30};
            //sumArray.printInfo(daySo);
            //Console.WriteLine($"Tinh Tong cac so chan (su dung for + if clause): {SumArray.SumUsingForAndIf(daySo)}");
            //Console.WriteLine($"Tinh Tong cac so chan (su dung foreach + if clause): {SumArray.SumUsingForeachAndIf(daySo)}");
            //Console.WriteLine($"Tinh Tong cac so chan (su dung while + if clause): {SumArray.SumUsingWhileAndIf(daySo)}");
            //Console.WriteLine($"Tinh Tong cac so chan (su dung while + while clause): {SumArray.SumUsingWhileAndWhile(daySo)}");

            //Sap xep tang dan
            SapXep.DaySo = new int[] { 11, 2, 21, 4, 5, 6, 21, 30 };
            var sapXep = new SapXep();
            sapXep.printInfo();
            /*
            var numbers = new List<int>() { 1, 2, 3, 4 };
            Console.WriteLine($"So phan tu cua list: {numbers.Count}");
            Console.WriteLine("Cac phan tu trong list:");
            
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                
            }
            var tong = 0;
            foreach (var number in numbers)
            {
                tong = tong + number;
            }
            Console.WriteLine($"Tong cac phan tu la: {tong}");
            var tongle = 0;
            var j = 0;
            foreach (var number in numbers)
            {
                if (j % 2 != 0)
                {
                    tongle = tongle + number;
                }
                j++;
            }
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung foreach loop + if clause): {tongle}");
            tongle = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    tongle = tongle + numbers[i];

                }
            }
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung for loop + if clause): {tongle}");
            j = 0;
            tongle = 0;
            while (j <= numbers.Count())
            {
                if (j % 2 != 0)
                {
                    tongle = tongle + numbers[j];

                }
                j++;
            }
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung while loop + if clause): {tongle}");
            j = 0;
            tongle = 0;
            while (j <= numbers.Count())
            {
                while(j % 2 != 0)
                {
                    tongle = tongle + numbers[j];
                    break;
                }
                j++;

            }
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung while while loop): {tongle}");
            var sv = new SinhVien("T01", "Viet Le", 1985);
            //var sinhVien = new List<SinhVien> { sv };
            var sinhVienS = new List<SinhVien>()
            {
                new SinhVien ("T02", "Khanh Nguyen", 1995),
                new SinhVien ("T03", "Le Nguyen", 1990)
            };
            // Using foreach
            foreach (var s in sinhVienS)
            {
                Console.WriteLine(s.ToString());
                
            }
            Console.WriteLine("$So sinh vien: {sinhVien.Count}");
            */
        }
    }
}