using NCalc;
using OpenXmlPowerTools;
using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXP.QA.Vile.Newbie.DelegateAnonymousLambda
{
    public class DeAnLa
    {
        int[] numbers = { 20, 9, 30, 5 };
        // Anonymous
        public void printAnonymous()
        {
            Array.ForEach(numbers, delegate (int x)
            {
                Console.WriteLine(x);
            });
            Console.ReadKey();
        }
        public void printLambda()
        {
            Array.ForEach(numbers, (int x) => { Console.WriteLine(x); });
            Array.ForEach(numbers, (int x) => { x = x + 5; Console.WriteLine(x); });
            // or bỏ cặp dấu ngoặc nhọn:
            Array.ForEach(numbers, (int x) => Console.WriteLine(x) );
            //or bỏ kiểu của biến x
            Array.ForEach(numbers, (x) => Console.WriteLine(x));
            // nếu chỉ có 1 tham số, có thể bỏ cả dấu ngoặc đơn
            Array.ForEach(numbers, x => Console.WriteLine(x));
            Array.ForEach(numbers, x => { x = x * 2; Console.WriteLine(x); });

            Console.ReadKey();
        }
        

        /*
        // 1 + 2
        delegate void ActionWithNumber(int x);

        int[] numbers = { 20, 15, 31, 16, 40, 7 };
        public void print()
        {
            //1 
            ActionWithNumber p = PrintTheNumber;

            ////2
            //ActionWithNumber print = delegate (int x)
            //{
            //    Console.WriteLine(x);
            //};

            ////3
            //ActionWithNumber newWay = num => Console.WriteLine(num);
            ////3
            //Func<int, int, int> func = (x, y) => x + y;
            //ProcessArray(numbers, p);
        }
        //1
        void PrintTheNumber(int x)
        {
            Console.WriteLine(x);
        }
        */
    }
}
