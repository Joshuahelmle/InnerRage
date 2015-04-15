using Styx;

namespace InnerRage.Core.Conditions.Glyphs
{
    class GlyphUnendingRageCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.GlyphUnendingRage);
        }
    }
}
