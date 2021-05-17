using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        Label FirstClicked=null;
        Label SecondClicked=null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {"!", "!", "N", "N", ",", ",", "k", "k",
         "b", "b", "v", "v", "w", "w", "z", "z"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                iconLabel.ForeColor = iconLabel.BackColor;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label ClickedLabel = sender as Label;
            if(ClickedLabel !=null)
            {
                if (ClickedLabel.ForeColor == Color.Black)
                    return;
                if(FirstClicked ==null)
                {
                    FirstClicked = ClickedLabel;
                    FirstClicked.ForeColor = Color.Black;
                    return;
                }
                SecondClicked = ClickedLabel;
                SecondClicked.ForeColor = Color.Black;
                CheckForWinners();
                if(FirstClicked.Text ==SecondClicked.Text)
                {
                    FirstClicked = null;
                    SecondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            FirstClicked.ForeColor = FirstClicked.BackColor;
            SecondClicked.ForeColor = SecondClicked.BackColor;
            FirstClicked = null;
            SecondClicked = null;
        }
        private void CheckForWinners()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel !=null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("You matched all the icons!", "Congratulations!");
            Close();
        }
    }
}
