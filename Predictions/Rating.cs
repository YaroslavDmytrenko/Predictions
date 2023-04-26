using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predictions
{
    internal class Rating
    {
        public static void Show()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            using (var reader = new StreamReader("rating.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(' ');

                    int key;
                    if (int.TryParse(values[0], out key))
                    {
                        dict[key] = values[1];
                    }
                }
            }
            foreach (KeyValuePair<int, string> entry in dict)
            {
                
                Console.WriteLine("{0} {1}", entry.Key, entry.Value);
            }
        }

    }
}
