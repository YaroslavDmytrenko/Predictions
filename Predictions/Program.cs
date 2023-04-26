using System;
using System.Text;

namespace Predictions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("World Cup Prediction 2022");

            while (true)
            {
                Console.WriteLine("Вибебiть пункт:");
                Console.WriteLine("1. Рейтинг команд");
                Console.WriteLine("2. Зробити прогноз на групову стадiю");
                Console.WriteLine("3. Зробити прогноз на етап плей-офф");
                Console.WriteLine("4. Дiзнатися оцiнку");
                Console.WriteLine("5. Завершити роботу");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.Clear();
                    Rating.Show();
                }
                else if (userInput == "2")
                    {
                    Console.Clear();
                    GroupStage.Start();
                }
                else if (userInput == "3")
                {
                    KnockoutStage.Start();
                    Prediction.checkKnockoutMark(Prediction.CorrectKnockoutStagePredictions, Prediction.KnockoutStagePredictions);
                }
                else if (userInput == "4")
                {
                    Prediction.finishMark();
                }
                else if (userInput == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Дякую за увагу.");
                    break;
                }
                else
                {
                    Console.WriteLine("Помилка.");
                }
            }
        }
    }
}