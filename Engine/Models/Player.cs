using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine.Models
{
    public abstract class Player : BaseCreature, IFightable
    {
        protected Player(int x, int y, int strength, int agility, int intelligence,int speed)
            : base(x, y)
        {
            this.BaseStrength = strength;
            this.BaseAgility = agility;
            this.BaseIntelligence = intelligence;
            this.BaseSpeed = speed;
            this.Level = 1;
        }
        public int CurrentHealth { get; set; }
        public int MaxHealth
        {
            get { return BaseStrength * Level; }
        }
        public int Defence
        {
            get { return BaseAgility * Level; }
        }

        public override void SetTarget(BaseCreature target)
        {
            
        }
        public abstract int Damage { get; }
        public abstract void Attack(IFightable target);

    }
}
