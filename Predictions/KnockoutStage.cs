using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Predictions
{
    public static class KnockoutStage
    {
        public static void Start()
        {
            string thirdPlace = "";
            string final = "";
            var match = File.ReadAllLines("knockout.csv")
                    .Take(8)
                    .ToList();
            Console.Clear();
            for (int i = 0, j = 0; i < 16; i++, j++)
            {
                Console.WriteLine("(Формат: 1 - перегома першої команди, 2 - перемога другої команди):");
                Console.WriteLine($"Match {i + 1}:");
                switch (i)
                {
                    case < 8:
                        Console.WriteLine("Введiть ваш прогноз на 1/8 ");
                        Console.WriteLine(match[j]);
                        break;
                    case < 12:
                        Console.WriteLine("Введiть ваш прогноз на 1/4 ");
                        Console.WriteLine(match[j] + " " + match[j + 1]);
                        break;
                    case < 14:
                        Console.WriteLine("Введiть ваш прогноз на 1/2 ");
                        Console.WriteLine(match[j] + " " + match[j + 2]);
                        break;
                    case 14:
                        Console.WriteLine("Матч за 3 мiсце");
                        Console.WriteLine(thirdPlace);
                        break;
                    case 15:
                        Console.WriteLine("Фiнал");
                        Console.WriteLine(final);
                        break;
                }

                string input = Console.ReadLine();
                if (input=="1" || input == "2") {
                    int matchPrediction = int.Parse(input);
                    if (i < 8)
                    {
                        string[] pred = match[j].Split(' ');
                        Prediction.KnockoutStagePredictions.Add(pred[matchPrediction - 1]);
                        match.Add(pred[matchPrediction - 1]);
                        Console.Clear();
                    }
                    else if (i < 12)
                    {
                        string test = match[j] + " " + match[j + 1];
                        string[] pred = test.Split(' ');
                        Prediction.KnockoutStagePredictions.Add(pred[matchPrediction - 1]);
                        match.Add(pred[matchPrediction - 1]);
                        j++;
                        Console.Clear();
                    }
                    else if (i < 14)
                    {
                        string test = match[j] + " " + match[j + 2];
                        string[] pred = test.Split(' ');
                        Prediction.KnockoutStagePredictions.Add(pred[matchPrediction - 1]);
                        if (matchPrediction == 1)
                        {
                            final += pred[matchPrediction - 1] + " ";
                            thirdPlace += pred[matchPrediction] + " ";
                        }
                        else
                        {
                            final += pred[matchPrediction - 1] + " ";
                            thirdPlace += pred[matchPrediction - 2] + " ";
                        }
                        Console.Clear();
                    }
                    else if (i == 14)
                    {
                        string[] pred = thirdPlace.Trim().Split(' ');
                        Prediction.KnockoutStagePredictions.Add(pred[matchPrediction - 1]);
                        Console.Clear();
                    }
                    else if (i == 15)
                    {
                        string[] pred = final.Trim().Split(' ');
                        Prediction.KnockoutStagePredictions.Add(pred[matchPrediction - 1]);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Помилка вводу. Спробуйте ще раз.");
                    i--;
                }
            }
        }
    }
}

