using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void plusButton_Click(object sender, EventArgs e)
        {
            int first = int.Parse(firstTextBox.Text);
            int second = int.Parse(secondTextBox.Text);
            int result = first + second;
            resultLabel.Text = result.ToString();
        }

        protected void subtractButton_Click(object sender, EventArgs e)
        {
            int first = int.Parse(firstTextBox.Text);
            int second = int.Parse(secondTextBox.Text);
            int result = first - second;
            resultLabel.Text = result.ToString();
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            int first = int.Parse(firstTextBox.Text);
            int second = int.Parse(secondTextBox.Text);
            int result = first * second;
            resultLabel.Text = result.ToString();
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            double first = double.Parse(firstTextBox.Text);
            double second = double.Parse(secondTextBox.Text);
            double result = first / second;
            resultLabel.Text = result.ToString();
        }
    }
}