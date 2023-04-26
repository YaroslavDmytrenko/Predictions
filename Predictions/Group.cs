using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predictions
{
    class Group
    {
        public string[] namesOfTeams;
        char letter;
        public Group(string team1, string team2, string team3, string team4, char letter)
        {
            namesOfTeams = new string[] { team1, team2, team3, team4 };
            this.letter = letter;
        }
        Dictionary<string, int> teams = new Dictionary<string, int>();


        public void check()
        {
            var sortedteams = from entry in teams orderby entry.Value descending select entry;
            Console.WriteLine($"Group {letter}");
            Console.WriteLine("-----------");
            Console.WriteLine("Вашi вiдповiдi:");
            foreach (KeyValuePair<string, int> kvp in sortedteams)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
            Console.WriteLine();
            Dictionary<string, int> correct = new Dictionary<string, int>();
            using (var reader = new StreamReader($"{letter}.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(' ');
                    correct.Add(values[0], int.Parse(values[1]));
                }
            }
            Console.WriteLine("Правильнi вiдповiдi:");
            foreach (KeyValuePair<string, int> item in correct)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
            int score = 0;
            Prediction.markGroupStage = 0;
            foreach (var item in teams)
            {
                if (correct.ContainsKey(item.Key) && correct[item.Key] == item.Value)
                {
                    score += 1;
                }
            }
            Console.WriteLine($"\nОцiнка: {score}\n");
            Prediction.markGroupStage += score;
        }

        public void simulate()
        {
            teams = play(namesOfTeams);
        }

        public Dictionary<string, int> play(string[] teams)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add(teams[0], 0);
            dict.Add(teams[1], 0);
            dict.Add(teams[2], 0);
            dict.Add(teams[3], 0);
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = i + 1; j < teams.Length; j++)
                {
                    Console.WriteLine("(Формат: 1 - перегома першої команди, 2 - перемога другої команди):");
                    Console.WriteLine("{0} vs {1}", teams[i], teams[j]);
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        dict[teams[i]] += 3;
                        Console.Clear();

                    }
                    else if (input == "2")
                    {
                        dict[teams[j]] += 3;
                        Console.Clear();
                    }
                    else if (input == "0")
                    {
                        dict[teams[i]] += 1;
                        dict[teams[j]] += 1;
                        Console.Clear();
                    }

                    else
                    {
                        Console.WriteLine("Помилка вводу. Спробуйте ще раз.");
                        j--;
                    }
                }
            }
            return dict;
        }


    }
}
