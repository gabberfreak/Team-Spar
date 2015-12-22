using System.Collections.Generic;
using System.Drawing;
using Engine.Interfaces;

namespace Engine.Models
{
    public abstract class BaseObject : IDrawable
    {
        private int size;
        protected BaseObject(int x, int y, int size)
        {
            this.X = x;
            this.Y = y;
            this.size = size;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle box
        {
            get
            {
                return new Rectangle(X,Y,size,size);
            }
        }

        public virtual Image Image { get; set; }
        public abstract void Render(System.Drawing.Graphics g);
        public abstract void Tick(List<BaseObject> creatures);

        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
    }
}
