using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.MobClasses
{
    class Zombie : Mob
    {
        private const int baseStr = 6;
        private const int baseAgi = 1;
        private const int baseInt = 1;
        private const int baseSpeed = 5;
        public Zombie(int x, int y, int level) : base(x,y,baseStr,baseAgi,baseInt,level,baseSpeed)
        {
            this.Image = (Bitmap)System.Drawing.Image.FromFile("../../../resources/init.png");
        }
        public override Bitmap Image { get; set; }
    }
}
