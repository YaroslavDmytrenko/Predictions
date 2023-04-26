using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Predictions
{
    public static class Prediction
    {
        public static ArrayList CorrectKnockoutStagePredictions = new ArrayList()
        {
            "Netherlands","Argentina","England","France","Croatia","Brazil","Morocco","Portugal",
            "Argentina","France","Croatia","Morocco","Argentina","France","Croatia","Argentina"
        };
        public static ArrayList KnockoutStagePredictions = new ArrayList();

        public static int mark {get;set;} = 0 ;
        public static int markKnockoutStage { get; set; } = 0;
        public static int markGroupStage { get; set; } = 0;



        


        public static void checkKnockoutMark(ArrayList correct, ArrayList test)
        {
            markKnockoutStage = 0;
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct[i].Equals(test[i]))
                {
                    markKnockoutStage++;
                }
            }
            Console.WriteLine($"Ваша оцiнка {markKnockoutStage}\n");
        }


        public static void finishMark()
        {
            Console.Clear();
            mark = markKnockoutStage + markGroupStage;
            Console.WriteLine($"Ваша фiнальний результат {mark}\n");
        }




    }
}
