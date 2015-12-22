using System;
using System.Drawing;
using System.Windows.Forms;
using Engine;

namespace Graphics
{
    public partial class SuperAdventure : Form
    {
        private Engine.Engine game;
        private Bitmap background;
        public SuperAdventure(Engine.Engine e)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.ClientSize = new Size(Constants.wWidth, Constants.wHeight);

            this.game = e;
            game.Start();
        }

        private void SuperAdventure_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.Running = false;
        }
        private void SuperAdventure_Paint(object sender, PaintEventArgs e)
        {
            if (game.Graphics == null)
            {
                game.Graphics = CreateGraphics();
            }
        }
        private void SuperAdventure_KeyUp(object sender, KeyEventArgs e)
        {
            game.Input.KeyUpHandler(sender, e);
        }
        private void SuperAdventure_KeyDown(object sender, KeyEventArgs e)
        {
            game.Input.KeyDownHandler(sender, e);
        }
    }
}
