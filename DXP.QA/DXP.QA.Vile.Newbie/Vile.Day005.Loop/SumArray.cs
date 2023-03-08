﻿using System;
namespace DXP.QA.Vile.Newbie.Vile.Day005.Loop
{
	

	public class SumArray
	{
        private static int tongChan;
        public static int SumUsingForAndIf(int[] numbers)
		{
			tongChan = 0;
			for (int i = 0; i < numbers.Length; i++)
			{
				if (numbers[i] % 2 == 0)
					tongChan = tongChan + numbers[i];
			}
			return tongChan;
		}

		public static int SumUsingForeachAndIf(int[] numbers)
		{
			tongChan = 0;
			foreach (var number in numbers)
			{
				if (number % 2 == 0)
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
				if (numbers[j] % 2 == 0)
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
				while (numbers[j] % 2 ==0)
				{
					tongChan = tongChan + numbers[j];
					break;
                }
				j++;	
			}
			return tongChan;
		}

		public void printInfo(int[] daySo)
		{
			Console.WriteLine("*****************************");
            Console.WriteLine("Tinh tong cac so chan trong ARRAY bang 4 cach:");
            Console.WriteLine($"Tinh Tong cac so chan (su dung for + if clause): {SumArray.SumUsingForAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung foreach + if clause): {SumArray.SumUsingForeachAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + if clause): {SumArray.SumUsingWhileAndIf(daySo)}");
            Console.WriteLine($"Tinh Tong cac so chan (su dung while + while clause): {SumArray.SumUsingWhileAndWhile(daySo)}");
            Console.WriteLine("Nhap phim bat ky de thoat");
            Console.WriteLine("*****************************");
            Console.ReadKey();
        }

    }
}

