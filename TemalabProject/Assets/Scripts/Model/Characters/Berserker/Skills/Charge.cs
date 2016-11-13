using System;
using System.Diagnostics;

namespace Assets.Scripts.Model.Skills {

    public class Charge : MiscSkill {

        public Charge() {
            cooldown = 2;
            name = "Charge";
            description = String.Format("This character gets +2 movement this round.");
        }

        protected override void OnExecute(Character source, object target) {
            source.TurnStats.ActionPoints--;
            source.TurnStats.RemainingMovement += 2;
        }

        public override double GetRange(Character source) {
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
