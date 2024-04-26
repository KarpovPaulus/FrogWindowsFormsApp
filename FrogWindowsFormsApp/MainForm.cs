using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrogWindowsFormsApp
{
    public partial class MainForm : Form
    {
        int startLocationEmptyBox = 440;
        public MainForm()
        {
            InitializeComponent();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Swap((PictureBox)sender);
            if(EndGame())
            {
                if(CanBeBetter(Convert.ToInt32(scoreLabel.Text)))
                {
                    MessageBox.Show("Лучший результат!");
                }
                else
                {
                    var result = MessageBox.Show("Можно лучше. Попробовать еще?", "Конец игры", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
            }
        }

        private void Swap(PictureBox clickedPicture)
        {
            var distance = Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width;

            if (distance > 2)
            {
                MessageBox.Show("Так нельзя");
            }
            else
            {
                var location = clickedPicture.Location;

                clickedPicture.Location = emptyPictureBox.Location;

                emptyPictureBox.Location = location;

                scoreLabel.Text = Convert.ToString(Convert.ToInt32(scoreLabel.Text) + 1);
            }
        }
        private bool EndGame()
        {
            if(leftPictureBox1.Location.X > emptyPictureBox.Location.X 
                && leftPictureBox2.Location.X > emptyPictureBox.Location.X
                && leftPictureBox3.Location.X > emptyPictureBox.Location.X
                && leftPictureBox4.Location.X > emptyPictureBox.Location.X
                && emptyPictureBox.Location.X == startLocationEmptyBox)
            {
                leftPictureBox1.Enabled = false;
                leftPictureBox2.Enabled = false;
                leftPictureBox3.Enabled = false;
                leftPictureBox4.Enabled = false;

                rightPictureBox1.Enabled = false;
                rightPictureBox2.Enabled = false;
                rightPictureBox3.Enabled = false;
                rightPictureBox4.Enabled = false;

                return true;
            }

            return false;
        }

        private bool CanBeBetter(int moves)
        {
            int bestMoves = 24;
            return moves == bestMoves;
        }

        private void рестартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила игры! Лягушка может перемещаться только на соседнюю плашку, " +
                "если эту плашку не занимает другая лягушка. Лягушка также может перепрыгнуть через одну лягушку " +
                "на соседнюю плашку, если эта плашка пустая.");
        }
    }
}
