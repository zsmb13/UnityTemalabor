using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public abstract class Skill {

        public int cooldown;
        public string name;
        public string description;

        public void Execute(Character source, object target) {
            if (target is Character) {
                if (!HasRequiredTeam(source, (Character) target)) {
                    return; // invalid target team
                }
            }

            if (!IsValidTarget(target)) {
                return;
            }

            OnExecute(source, target);
        }

        protected abstract bool HasRequiredTeam(Character source, Character target);

        protected abstract void OnExecute(Character source, object target);

        public abstract double GetRange(Character source);

        public abstract bool IsAvailable(TurnStats turnStats);

        protected abstract bool IsValidTarget(object target);
        
        public override string ToString() {
            return name + ": " + description;
        }

    }

}
