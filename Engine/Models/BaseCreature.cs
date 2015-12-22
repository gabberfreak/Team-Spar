using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Engine.Interfaces;

namespace Engine.Models
{
    public abstract class BaseCreature : BaseObject, IMovable
    {
        //private List<Item> items;

        protected BaseCreature(int x, int y, int size)
            : base(x, y, size)
        {
        }

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
                if (XDir != 0 && YDir == 0)
                {
                    this.X += this.XDir*this.Speed;
                }
                else this.X += this.XDir;
            }
            if(InBoundsY())
            {
                if (YDir != 0 && XDir == 0)
                {
                    this.Y += this.YDir*this.Speed;
                }
                else this.Y += this.YDir;
            }
        }

        public abstract void SetTarget(BaseCreature target);

        public override void Tick(List<BaseObject> creatures)
        {
            var collided = creatures.Any(this.Intersects);
            if (!collided)
            {
                Move();
            }
        }

        public bool InBoundsX()
        {
            if ((this.X + this.XDir*this.Speed) <= 0 || (this.X + this.XDir*this.Speed) >= Constants.gWidth)
            {
                return false;
            }
            return true;
        }

        public bool InBoundsY()
        {
            if ((this.Y + this.YDir * this.Speed) <= 0 || (this.Y + this.YDir * this.Speed) >= Constants.gHeight)
            {
                return false;
            }
            return true;
        }

        public bool Intersects(BaseObject obj)
        {
            if (this.Equals(obj))
            {
                return false;
            }
            Rectangle checker = new Rectangle(box.X, box.Y, box.Width,box.Height);
            if (XDir != 0)
            {
                checker.Offset(this.XDir * this.Speed, 0);
                if (checker.IntersectsWith(obj.box))
                {
                    return true;
                }
            }
            if (YDir != 0)
            {
                checker.Offset(0, this.YDir * this.Speed);
                if (checker.IntersectsWith(obj.box))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
