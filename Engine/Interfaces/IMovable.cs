using System.Collections.Generic;
using Engine.Models;

namespace Engine.Interfaces
{
    public interface IMovable : ICollidable
    {
        int XDir { get; set; }
        int YDir { get; set; }
        void SetTarget(BaseCreature target);
        int BaseSpeed { get; set; }
        void Move();
    }
}
