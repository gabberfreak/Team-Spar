using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Interfaces;
using SlimDX.Direct3D10;

namespace Engine.Models
{
    public abstract class BaseCreature : IMovable, IDrawable
    {
        //private List<Item> items;

        protected BaseCreature(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public abstract Bitmap Image { get; set; }
        public int XDir { get; set; }
        public int YDir { get; set; }
        public int BaseSpeed { get; set; }
        public int BaseStrength { get; protected set; }
        public int BaseAgility { get; protected set; }
        public int BaseIntelligence { get; protected set; }

        public int Speed
        {
            get { return BaseAgility/2*Level > 0 ? BaseAgility/2*Level : 1; }
        }
        public int Level { get; set; }

        public virtual void Move()
        {
            if (InBoundsX())
            {
                if (XDir != 0)
                {
                    this.X += this.XDir*this.Speed;
                }
            }
            if(InBoundsY()){
            if (YDir != 0)
                {
                    this.Y += this.YDir * this.Speed;
                }
            }
        }

        public abstract void SetTarget(BaseCreature target);
        

        public virtual void Tick()
        {
            Move();
        }

        public virtual void Render(Graphics g)
        {
            try
            {
                g.DrawImage(this.Image,new Rectangle(this.X, this.Y, this.Image.Width, this.Image.Height));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //var p = new Rectangle(X, Y, 10, 10);
            //g.DrawRectangle(Pens.Red, p);
                //FillRectangle(Brushes.Red,p);
        }

        public bool InBoundsX()
        {
            if ((this.X + this.XDir*this.Speed) <= 0 || (this.X + this.Image.Width + this.XDir*this.Speed) >= Constants.gWidth)
            {
                return false;
            }
            return true;
        }

        public bool InBoundsY()
        {
            if ((this.Y + this.YDir * this.Speed) <= 0 || (this.Y + this.Image.Height + this.YDir * this.Speed) >= Constants.gHeight)
            {
                return false;
            }
            return true;
        }
    }
}
