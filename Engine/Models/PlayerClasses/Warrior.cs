using System;
using System.Drawing;
using Engine.Interfaces;

namespace Engine.Models.PlayerClasses
{
    public class Warrior : Player
    {
        private const int baseStr = 6;
        private const int baseAgi = 4;
        private const int baseInt = 3;
        private const int baseSpeed = 3;
        private Image image;
        public Warrior(int x, int y) : base(x, y, baseStr, baseAgi, baseInt, baseSpeed)
        {
            this.Image = (Bitmap) Image.FromFile("../../../resources/MightySword.png");
        }

        public override int Damage
        {
            get { throw new NotImplementedException(); }
        }

        public override void Attack(IFightable target)
        {
            throw new NotImplementedException();
        }

        public override Image Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public override void Render(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Blue, X, Y, Size,Size);
        }
    }
}
