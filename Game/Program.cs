using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics;

namespace Game
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var engine = new Engine.Engine();
            var app = new SuperAdventure(engine);
            Application.Run(app);
        }
    }
}
