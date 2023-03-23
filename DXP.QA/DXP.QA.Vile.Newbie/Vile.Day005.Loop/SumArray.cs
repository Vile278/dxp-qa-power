using System;
using DXP.QA.Vile.Newbie.Vile.Common;

namespace DXP.QA.Vile.Newbie.Vile.Day005.Loop
{
	abstract class A
	{
		public abstract void AMethod();
		
		public virtual void OtherMethod()
		{
			Console.WriteLine("Other method code in father");
            Console.WriteLine("Other method code in father");
            Console.WriteLine("Other method code in father");
            Console.WriteLine("Other method code in father");
            Console.WriteLine("Other method code in father");

        }
	}

	class B : A
	{
		public int AMethod(int value) { return 3; }

        public override void AMethod()
        {
            throw new NotImplementedException();
        }

        public override void OtherMethod()
        {
            base.OtherMethod();

			Console.WriteLine("Child method override");
        }
    }

	public class SumArray : So
	{
        private static int tongChan;
		public static int[]? daySo;
        public static int SumUsingForAndIf(int[] numbers)
		{
			tongChan = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (So.SoChan(numbers[i]))//(numbers[i] % 2 == 0)
					tongChan = tongChan + numbers[i];
			}
			return tongChan;
		}

		public static int SumUsingForeachAndIf(int[] numbers)
		{
			tongChan = 0;
			foreach (var number in numbers)
			{
				if (So.SoChan(number)) //(number % 2 == 0)
					tongChan = tongChan + number;
			}
			return tongChan;
		}

		public static int SumUsingWhileAndIf(int[] numbers)
		{
			tongChan = 0;
			var j = 0;
			while (j < numbers.Length)
			{
				if (So.SoChan(numbers[j]))// (numbers[j] % 2 == 0)
					tongChan = tongChan + numbers[j];
				j++;
			}
			return tongChan;
		}

		public static int SumUsingWhileAndWhile(int[] numbers)
		{
			tongChan = 0;
			var j = 0;
			while (j <numbers.Length)
			{
				while (So.SoChan(numbers[j]))// (numbers[j] % 2 ==0)
                {
					tongChan = tongChan + numbers[j];
					break;
                }
				j++;	
			}
			return tongChan;
		}

		public override void printInfo()
		{
			Console.WriteLine("*****************************");
            Console.WriteLine("Tinh tong cac so chan trong ARRAY bang 4 cach:");
			Console.WriteLine("Day so nguyen thuy:");
            foreach (int So in daySo)
            {
                Console.Write($"{So}; ");
            }
			Console.WriteLine();
            Console.WriteLine($"Tinh Tong cac so chan (su dung for + if clause): {SumArray.SumUsingForAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung foreach + if clause): {SumArray.SumUsingForeachAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + if clause): {SumArray.SumUsingWhileAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + while clause): {SumArray.SumUsingWhileAndWhile(daySo)}");
            Console.WriteLine("Nhap phim bat ky de thoat");
            Console.WriteLine("*****************************");
            Console.ReadKey();
        }
        public static void printInforUsingPolymorphism()
		{
            Console.WriteLine("*****************************");
            Console.WriteLine("Tinh tong cac so chan trong ARRAY bang 4 cach:");
            Console.WriteLine("Day so nguyen thuy:");
            foreach (int So in daySo)
            {
                Console.Write($"{So}; ");
            }
            Console.WriteLine();
            Console.WriteLine($"Tinh Tong cac so chan (su dung for + if clause): {SumArray.SumUsingForAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung foreach + if clause): {SumArray.SumUsingForeachAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + if clause): {SumArray.SumUsingWhileAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + while clause): {SumArray.SumUsingWhileAndWhile(daySo)}");
            Console.WriteLine("Nhap phim bat ky de thoat");
            Console.WriteLine("*****************************");
            Console.ReadKey();
        }
        public SumArray()
		{
			daySo = new int[] { 50, 42, 60, 55 };
		}

    }
}

