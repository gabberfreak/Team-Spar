using System.Collections.Generic;
using System.Drawing;

namespace Engine.Models
{
    public class Box : BaseObject
    {
        private const int size = 50;
        public Box(int x, int y) : base(x, y, size)
        {
            this.Image = this.Image = Image.FromFile("../../../resources/block.jpg");
        }

        public override Image Image { get; set; }

        public override void Render(System.Drawing.Graphics g)
        {
            g.FillRectangle(Brushes.Brown, X, Y, size, size);
            //g.DrawImage(Image,X,Y,50,50);
        }

        public override void Tick(List<BaseObject> creatures)
        {
        }
    }
}
