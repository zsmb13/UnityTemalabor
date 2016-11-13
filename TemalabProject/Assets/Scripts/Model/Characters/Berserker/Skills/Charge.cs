using System;
using System.Diagnostics;

namespace Assets.Scripts.Model.Skills {

    public class Charge : MiscSkill {
        protected override void OnExecute(Character source, object target) {
            source.TurnStats.ActionPoints--;
            source.TurnStats.RemainingMovement += 2;
        }

        public override double GetRange(Character source) {
            return -1;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            // TODO check cooldown? Or do we already check that somewhere else?
            return true;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target == source;
        }
    }

}
