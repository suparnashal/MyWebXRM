using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helpers
{
   public class DateTimePicker
    {
        public static int currentDate => DateTime.Now.Day ;
        public static int currentMonth => DateTime.Now.Month;
        public static int currentYear => DateTime.Now.Year;

        
    }
}
