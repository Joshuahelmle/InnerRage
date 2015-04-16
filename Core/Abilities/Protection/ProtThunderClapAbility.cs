using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ProtThunderClapAbility : AbilityBase
    {
        public ProtThunderClapAbility()
            : base(WoWSpell.FromId(SpellBook.SpellThunderClap), true, true)
        {
            Category = AbilityCategory.Combat;
        }
    }
}