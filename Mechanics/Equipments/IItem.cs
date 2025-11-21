using Aria.Mechanics.Abilities;
using Aria.Mechanics.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aria.Mechanics.Equipments
{
    internal interface IItem
    {
        string Name { get; }
        string Description { get; }
        ItemStats Stats { get; }
        IAbility Ability { get; }
    }
}
