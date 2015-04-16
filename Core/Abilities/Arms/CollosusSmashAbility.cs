using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    internal class CollosusSmashAbility : AbilityBase
    {
        public CollosusSmashAbility()
            : base(WoWSpell.FromId(SpellBook.SpellCollosusSmash), true, true)
        {
            Category = AbilityCategory.Combat;
        }
    }
}