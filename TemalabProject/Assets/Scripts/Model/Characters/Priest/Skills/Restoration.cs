using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model.Skills {

    public class Restoration : FriendlySkill {

        private static readonly int cooldown = 4;
        private static readonly string name = "Restoration";
        private static readonly string description = "Restore 150 health on a friendly unit.";

        private static readonly int healAmount = 150;

        public Restoration() : base(name, description, cooldown) {}

        public override float GetRange(Character source) {
            return -1;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0 && !turnStats.ActiveAbilityUsed;
        }

        protected override void OnExecute(Character source, object target) {
            Character friend = target as Character;

            var missingHealth = friend.ConstStats.TotalHealth - friend.GameStats.RemainingHealth;
            var actualHealAmount = Math.Min(missingHealth, healAmount);
            friend.GameStats.RemainingHealth += actualHealAmount;

            source.TurnStats.ActiveAbilityUsed = true;
            source.TurnStats.ActionPoints--;

            source.Animate("Active");
        }

    }

}