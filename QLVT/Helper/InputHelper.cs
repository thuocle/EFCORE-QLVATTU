using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVT.Helper
{
    public enum inputType
    {
        ThemGT, ThemTT
    }
    public class InputHelper
    {
        public static int InputINT(string msg, string err, int min = 0)
        {
            bool check;
            int ret;
            do
            {
                Console.WriteLine(msg);
                check = int.TryParse(Console.ReadLine(), out ret);
                check = check && ret > min;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }

        public static string InputSTR(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length > min && ret.Length < max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }

        public static DateTime InputDT(string msg, string err, DateTime min , DateTime max)
        {
            bool check;
            DateTime ret;
            do
            {
                Console.WriteLine(msg);
                check = DateTime.TryParse(Console.ReadLine(), out ret);
                check = check && ret > min && ret < max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
    }
}
