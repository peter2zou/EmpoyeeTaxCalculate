using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTaxCalculate
{
    public static class Utilities
    {
        public static T InputData<T>(string info)
        {
            string inputValue = null;
            T value = default(T);
            Console.WriteLine(info);
            bool isExit = false;
            do
            {
                inputValue = Console.ReadLine();
                try
                {
                    value = (T)Convert.ChangeType(inputValue, typeof(T));
                    isExit = true;
                }
                catch
                {
                    Console.WriteLine("Invalid Value! Try it agin");
                }
            } while (!isExit);
            return value;
        }

        public static string ExtendedToString(this IList<ItemDeduction> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var itemDeduction in list)
                sb.AppendLine(itemDeduction.ExtendedToString());
            return sb.ToString();
        }

        public static decimal TotalChargeAmount(this IList<ItemDeduction> list)
        {
            decimal totalChargeAmount = 0;
            foreach (var itemDeduction in list)
                totalChargeAmount += itemDeduction.DeductionCharge;
            return totalChargeAmount;
        }

        public static string ExtendedToString(this ItemDeduction itemDeduction)
        {
            return string.Format("{0}:{1:C}", itemDeduction.DeductionItemName, itemDeduction.DeductionCharge);
        } 
    }
}
