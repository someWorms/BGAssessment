using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANPR.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string DropR(this string str)
        {
            return str.Substring(1);
        }
    }
}
