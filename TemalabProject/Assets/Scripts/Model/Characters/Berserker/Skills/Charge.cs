using System;
using System.Diagnostics;

namespace Assets.Scripts.Model.Skills {

    public class Charge : MiscSkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Charge";
        private static readonly int extramovement = 2;
        private static readonly float range = -1.0f;
        private static readonly string description = String.Format("This character gets +{0} movement this round.",extramovement);

        public Charge() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            source.TurnStats.RemainingMovement += extramovement;

            source.Animate("Active");
            source.TurnStats.ActionPoints--;            
            source.TurnStats.ActiveAbilityUsed = true;
            
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target == source;
        }
    }

}
