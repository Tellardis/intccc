using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intcc.Model
{
    public static class Calculate
    {
        public static int Total { get; set; }

        public static void Add(int value, int multiplayer)
        {
            Total += value * multiplayer;
        }

        public static void Clear()
        {
            Total = 0;
        }
    }
}
