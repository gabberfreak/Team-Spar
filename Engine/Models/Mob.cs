using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine.Models
{
    abstract class Mob : BaseCreature, IFightable
    {
        protected Mob(int x, int y, int strength, int agility, int intelligence, int level, int speed) : base(x, y)
        {
            this.BaseStrength = strength;
            this.BaseAgility = agility;
            this.BaseIntelligence = intelligence;
            this.BaseSpeed = speed;
            this.Level = level;
        }
        public override void SetTarget(BaseCreature target)
        {
            if (this.X < target.X - 10)
            {
                this.XDir = 1;
            }else if (this.X > target.X + 10)
            {
                this.XDir = -1;
            }
            else
            {
                this.XDir = 0;
            }

            if (this.Y < target.Y - 10)
            {
                this.YDir = 1;
            }
            else if (this.Y > target.Y + 10)
            {
                this.YDir = -1;
            }
            else
            {
                this.YDir = 0;
            }
        }

        public int CurrentHealth { get; set; }
        public int MaxHealth { get; private set; }
        public int Defence { get; private set; }
        public int Damage { get; private set; }
        public void Attack(IFightable target)
        {
            throw new NotImplementedException();
        }
    }
}
