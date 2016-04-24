using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionGame
{
    public partial class SizeForm : Form
    {
        Game1 game;
        

        public SizeForm(Game1 game)
        {
            InitializeComponent();
            this.game = game;
            
        }

        private void SizeForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.screensize = new Microsoft.Xna.Framework.Point((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            game.isFullScreen = checkBox1.Checked;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }
    }
}
