using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aria.GameObjects;
using Aria.Systems.Clocks;

namespace Aria.Mechanics.Abilities
{
    public interface IAbility
    {
        string Name { get; }

        string Description { get; }

        float Cooldown { get; }

        Clock Clock { get; }

        bool IsActive { get; }

        bool CanBeCast();

        void Cast();

        GameObject Owner { get; }
    }
}
