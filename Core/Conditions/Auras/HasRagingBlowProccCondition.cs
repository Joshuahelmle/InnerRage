﻿using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    internal class HasRagingBlowProccCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraRagingBlow);
        }
    }
}