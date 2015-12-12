using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Engine.Engine game;
        public SuperAdventure()
        {
            game = new Engine.Engine();
            InitializeComponent();
            game.Start();
            
        }

       private void SuperAdventure_KeyDown(object sender, KeyEventArgs e)
        {
            game.Input.KeyDownHandler(sender,e);
        }
        private void SuperAdventure_KeyUp(object sender, KeyEventArgs e)
        {
            game.Input.KeyUpHandler(sender,e);
        }

        private void SuperAdventure_Paint(object sender, PaintEventArgs e)
        {
            game.Graphics = CreateGraphics();
        }

        private void SuperAdventure_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.Stop();
            Application.Exit();
        }
    }
}
