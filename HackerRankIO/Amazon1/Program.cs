using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = new string[10] { "seller1", "item1", "seller1", "item2", "seller2", "item2", "seller2", "item3", "seller3", "item3" };
            //Create a dictionary of the sellers
            Dictionary<string, List<string>> vendors = new Dictionary<string, List<string>>();
            Dictionary<string, int> sellers = new Dictionary<string, int>();
            //find out how many of each item we have
            for (int i = 0; i < items.Length - 1; i = i + 2)
            {
                if (vendors.ContainsKey(items[i]))
                {
                    vendors[items[i]].Add(items[i + 1]); 
                }
                else
                {
                    //Add to the vendors
                    List<string> newList = new List<string>();
                    newList.Add(items[i + 1]);
                    vendors.Add(items[i], newList);
                }

                //Add to the counting Dictionary
                if (sellers.ContainsKey(items[i + 1]))
                {
                    sellers[items[i + 1]] += 1;
                }
                else
                {
                    sellers.Add(items[i + 1], 1);
                }
            }

            //Get top items vendor
            var topItems = (from sell in sellers
                            where sell.Value == (from sell1 in sellers select sell1.Value).Max()
                            select sell.Key).ToList();

            List<string> results = new List<string>();
            foreach(var vendor in vendors)
            {
                bool sellsTop = true;
                foreach(string topItem in topItems)
                {
                    if (!vendor.Value.Contains(topItem))
                    {
                        sellsTop = false;
                        break;
                    }
                }
                if (sellsTop)
                {
                    results.Add(vendor.Key);
                }
            }
            //return the vendors we see
            Console.WriteLine(String.Join(" ", results));
            Console.ReadLine();
        }
    }
}
