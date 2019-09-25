using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result =  WorkDayCalculator.Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            }; 

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
            
            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }
        //other tests
        [TestMethod]
        public void TestOneWeekendsInside()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 23))
            };
            
            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 26)));
        }
        [TestMethod]
        public void TestWeekendsAfterPeriod()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 7;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 30))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 26)));
        }
        [TestMethod]
        public void TestWeekendsBeforePeriod()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 10), new DateTime(2017, 4, 15))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 24)));
        }
        [TestMethod]
        public void TestStartDayInWeekend()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 20), new DateTime(2017, 4, 21))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 26)));
        }
        [TestMethod]
        public void TestEndDayInWeekend()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 24), new DateTime(2017, 4, 26))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 27)));
        }
        [TestMethod]
        public void TestBetweenWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 10), new DateTime(2017, 4, 15)),
                new WeekEnd(new DateTime(2017, 4, 25), new DateTime(2017, 4, 29))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 24)));
        }
        [TestMethod]
        public void TestBeginAndEndInWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 13);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 10), new DateTime(2017, 4, 15)),
                new WeekEnd(new DateTime(2017, 4, 18), new DateTime(2017, 4, 22))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 25)));
        }
        [TestMethod]
        public void TestBeginAndEndIn1dayWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 13);
            int count = 3;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 13), new DateTime(2017, 4, 13)),
                new WeekEnd(new DateTime(2017, 4, 18), new DateTime(2017, 4, 18))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 16)));
        }


        [TestMethod]
        public void Test3Weekends()
        {
            DateTime startDate = new DateTime(2017, 4, 20);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd(new DateTime(2017, 4, 21), new DateTime(2017, 4, 21)),
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 26), new DateTime(2017, 4, 29))
            };

            DateTime result = WorkDayCalculator.Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 5, 2)));
        }







    }
}
