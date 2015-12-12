using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine.Models.PlayerClasses
{
    public class Warrior : Player
    {
        private const int baseStr = 6;
        private const int baseAgi = 4;
        private const int baseInt = 3;
        private const int baseSpeed = 3;
        private Bitmap image;
        public Warrior(int x, int y) : base(x, y, baseStr, baseAgi, baseInt, baseSpeed)
        {
            this.Image = (Bitmap) System.Drawing.Image.FromFile("../../../resources/hero.png");
        }

        public override int Damage
        {
            get { throw new NotImplementedException(); }
        }

        public override void Attack(IFightable target)
        {
            throw new NotImplementedException();
        }

        public override Bitmap Image
        {
            get
            {
                var cropArea = new Rectangle(310,0,150,310);
                return this.image.Clone(cropArea, this.image.PixelFormat);
            }
            set { this.image = value; }
        }
     }
}
