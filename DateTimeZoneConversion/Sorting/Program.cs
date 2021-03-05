using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lstLength = new List<int>();
            //input 
            String[] inputItem = { "1101A", "1000", "AB100", "1100", "3001", "2000A", "3500", "2000" };

            //declare dictionary to hold strings of equal length
            Dictionary<int, List<string>> dictOfString = new Dictionary<int, List<string>>();

            //put strings of same length  to same key in dictionary
            foreach (var item in inputItem)
            {
                int itemLen = item.Length;
                if (dictOfString.ContainsKey(itemLen))
                {
                    dictOfString[itemLen].Add(item);
                }
                else
                {
                    lstLength.Add(itemLen);
                    List<string> lst = new List<string>();
                    lst.Add(item);
                    dictOfString[itemLen] = lst;
                }
            }

            //sorting strings of equal length in dictionary
            foreach (var item in dictOfString)
            {
                item.Value.Sort();
            }
            // sorting to get sorted keys in dictionary
            lstLength.Sort();


            //display sorted list
            Console.Write("Sorted items :{ ");
            foreach (var item in lstLength)
            {
                foreach (var sortedItem in dictOfString[item])
                {
                    Console.Write("\"" + sortedItem + "\" ");
                }

            }
            Console.WriteLine(" }");

            Console.ReadLine();
        }

    }
}
