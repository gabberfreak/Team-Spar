using System.Windows.Forms;
using Engine.Interfaces;
using Engine.Models;


namespace Engine.InputHandler
{
    public class Input
    {
        private IMovable obj;
        public Input(IMovable obj)
        {
            this.obj = obj;
        }
        
        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    obj.YDir = -1;
                    break;
                case Keys.Down:
                    obj.YDir = 1;
                    break;
                case Keys.Left:
                    obj.XDir = -1;
                    break;
                case Keys.Right:
                    obj.XDir = 1;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        public void KeyUpHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    obj.YDir = 0;
                    break;
                case Keys.Down:
                    obj.YDir = 0;
                    break;
                case Keys.Left:
                    obj.XDir = 0;
                    break;
                case Keys.Right:
                    obj.XDir = 0;
                    break;
            }
        }
    }
}
