using System;
using DXP.QA.Vile.Newbie.Vile.Common;
namespace DXP.QA.Vile.Newbie.Vile.Day005.Loop
{
	public class SumList : So 
	{
        private static int tongLe;

        public static List<int> daySo; 
        public static int SumUsingForAndIf(List<int> numbers)
		{
            tongLe = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (!So.SoChan(i)) //(i % 2 != 0)
                {
                    tongLe = tongLe + numbers[i];

                }
            }
            return tongLe;
        }
        public static int SumUsingForeachAndIf(List<int> numbers)
        {
            tongLe = 0;
            var j = 0;
            foreach (var number in numbers)
            {
                if (!So.SoChan(j)) //(j % 2 != 0)
                {
                    tongLe = tongLe + number;
                }
                j++;
            }
            return tongLe;

        }
        public static int SumUsingWhileAndIf(List<int> numbers)
        {
            var j = 0;
            tongLe = 0;
            while (j <= numbers.Count())
            {
                if (!So.SoChan(j))//(j % 2 != 0)
                {
                    tongLe = tongLe + numbers[j];

                }
                j++;
            }
            return tongLe;
        }
        public static int SumUsingWhileAndWhile(List<int> numbers)
        {
            var j = 0;
            tongLe = 0;
            while (j <= numbers.Count())
            {
                while (!So.SoChan(j)) //(j % 2 != 0)
                {
                    tongLe = tongLe + numbers[j];
                    break;
                }
                j++;
            }
            return tongLe;
        }
        public override void printInfo() //(List<int> daySo)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Tinh tong cac phan tu le trong LIST bang 4 cach:");
            Console.WriteLine("Day so nguyen thuy:");
            foreach (int So in daySo)
            {
                Console.Write($"{So}; ");
            }
            Console.WriteLine();
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung for + if clause): {SumList.SumUsingForAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung foreach + if clause): {SumList.SumUsingForeachAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung while + if clause): {SumList.SumUsingWhileAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac phan tu le (su dung while + while clause): {SumList.SumUsingWhileAndWhile(daySo)}");
            Console.WriteLine("Nhap phim bat ky de thoat");
            Console.WriteLine("*****************************");
            Console.ReadKey();
        }
        public SumList()
        {
            daySo = new List<int> { 9, 8, 29, 6 };
        }
    }
}

