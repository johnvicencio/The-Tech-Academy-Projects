using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";

            int largestNumberIndex = 0;
            int smallestNumberIndex = 0;


            for (int i = 0; i < names.Length; i++)
            {
                // Is this the largest count so far?
                if (numbers[i] > numbers[largestNumberIndex])
                {
                    largestNumberIndex = i;
                }

                // Is this the smallest count so far?
                if (numbers[i] < numbers[smallestNumberIndex])
                {
                    smallestNumberIndex = i;
                }

            }

            result = String.Format("Most battles belong to: {0} (Value: {1})", names[largestNumberIndex], numbers[largestNumberIndex]);
            result += String.Format("<br />Least battles belong to: {0} (Value: {1})", names[smallestNumberIndex], numbers[smallestNumberIndex]);

            resultLabel.Text = result;
        }
    }
}