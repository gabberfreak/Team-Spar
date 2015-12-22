using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.MobClasses
{
    public class Boss : Mob
    {
        private const int baseStr = 6;
        private const int baseAgi = 1;
        private const int baseInt = 1;
        private const int baseSpeed = 5;
        private const int size = 75;

        public Boss(int x, int y, int level) : base(x,y,baseStr,baseAgi,baseInt,level,baseSpeed,size)
        {
            this.Image = Image.FromFile("../../../resources/init.png");
        }
        public override Image Image { get; set; }
        public override void Render(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.DarkRed, X, Y, size, size);
        }
    }
}
