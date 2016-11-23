using System;
using System.Diagnostics;

namespace Assets.Scripts.Model.Skills {

    public class Charge : MiscSkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Charge";
        private static readonly string description = "This character gets +2 movement this round.";

        public Charge() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            source.TurnStats.ActionPoints--;
            source.TurnStats.RemainingMovement += 2;
        }

        public override float GetRange(Character source) {
            return -1;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target == source;
        }
    }

}
