using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predictions
{
    public static class GroupStage
    {
        public static void Start()
        {
            Group groupA = new Group("Qatar", "Ecuador", "Senegal", "Netherlangs", 'A');
            groupA.simulate();
            groupA.check();

            Group groupB = new Group("England", "United States", "Wales", "Iran", 'B');
            groupB.simulate();
            groupB.check();

            Group groupC = new Group("Mexico", "Poland", "Argentina", "Saudi Arabia", 'C');
            groupC.simulate();
            groupC.check();

            Group groupD = new Group("France", "Australia", "Denmark", "Tunisia", 'D');
            groupD.simulate();
            groupD.check();

            Group groupE = new Group("Spain", "Costa Rica", "Germany", "Japan", 'E');
            groupE.simulate();
            groupE.check();

            Group groupF = new Group("Belgium", "Canada", "Morocco", "Croatia", 'F');
            groupF.simulate();
            groupF.check();

            Group groupG = new Group("Switzerland", "Cameroon", "Brazil", "Serbia", 'G');
            groupG.simulate();
            groupG.check();

            Group groupH = new Group("Portugal", "South Korea", "Ghana", "Uruguay", 'H');
            groupH.simulate();
            groupH.check();
        }
    }
    
}
