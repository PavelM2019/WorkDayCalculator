using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpTest;


//add console app
namespace WorkDayCalculatorTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var Weekend = new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25));
            var EndDate = WorkDayCalculator.Calculate(new DateTime(2017, 4, 21), 5, Weekend);
            Console.WriteLine(EndDate);
            Console.ReadKey();
        }
    }
}
