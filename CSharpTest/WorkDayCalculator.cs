using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public static class WorkDayCalculator 
    {
        //we only need a class method
        public static DateTime Calculate(DateTime startDate, int dayCount, params WeekEnd[] Weekend)
        {
            if (Weekend != null)
            {
                //change the start date if it's on the weekend
                foreach (var item in Weekend)
                {
                    if (startDate >= item.StartDate && startDate <= item.EndDate)
                    {
                        startDate = item.EndDate.AddDays(1);
                    }

                }
            }
            
            DateTime EndDate = startDate;
            for (int i =1; i <= dayCount-1; i++)
            {
                //no weekends
                if (Weekend != null)
                {
                    foreach (var item in Weekend)
                    {
                        if (EndDate.AddDays(1) >= item.StartDate && EndDate.AddDays(1) <= item.EndDate)
                        {
                            EndDate = item.EndDate;
                        } 
                    }
                }
                EndDate = EndDate.AddDays(1);            
            }
            return EndDate;
        }
    }
}
