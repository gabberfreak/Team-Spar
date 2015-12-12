using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Interfaces
{
    public interface IFightable
    {
        int CurrentHealth { get; set; }
        int MaxHealth { get; }
        int Defence { get; }
        int Damage { get; }
        void Attack(IFightable target);

    }
}
