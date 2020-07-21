using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator
{
    public static class DateUtils
    {
        public static bool isDelaying(long timeInMillis, int interval)
        {
            return ((DateTime.Now.Ticks - timeInMillis) / 10000) > interval;
        }
    }
}
