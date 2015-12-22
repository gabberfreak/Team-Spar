using System.Windows.Forms;
using Engine.Interfaces;


namespace Engine.InputHandler
{
    public class Input
    {
        private Engine e;
        private IMovable obj;
        public Input(Engine e)
        {
            this.obj = e.Player;
            this.e = e;
        }
        
        public void KeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (obj.YDir > 0)
                    {
                        break;
                    }
                    obj.YDir = -1;
                    break;
                case Keys.Down:
                    if (obj.YDir < 0)
                    {
                        break;
                    }
                    obj.YDir = 1;
                    break;
                case Keys.Left:
                    if (obj.XDir > 0)
                    {
                        break;
                    }
                    obj.XDir = -1;
                    break;
                case Keys.Right:
                    if (obj.XDir < 0)
                    {
                        break;
                    }
                    obj.XDir = 1;
                    break;
                case Keys.Escape:
                    this.e.Running = false;
                    Application.Exit();
                    break;
            }
        }

        public void KeyUpHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (obj.YDir > 0)
                    {
                        break;
                    }
                    obj.YDir = 0;
                    break;
                case Keys.Down:
                    if (obj.YDir < 0)
                    {
                        break;
                    }
                    obj.YDir = 0;
                    break;
                case Keys.Left:
                    if (obj.XDir > 0)
                    {
                        break;
                    }
                    obj.XDir = 0;
                    break;
                case Keys.Right:
                    if (obj.XDir < 0)
                    {
                        break;
                    }
                    obj.XDir = 0;
                    break;
            }
        }
    }
}
