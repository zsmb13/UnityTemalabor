using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {
    public class BasicAttack : Skill {
        public override void Execute(Character source, object target) {
            if (!IsValidTarget(target)) {
                return;
            }

            Character enemy = target as Character;

            Result result = new Result(0, false);
            if (enemy.TryMagicDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnMagicDamage(30, 0);
            }

            source.OnAttack();

            // afterattack
            // afterdefense
        }

        public override double GetRange() {
            return 10;
        }

        public override bool IsAvailable(TurnStats stats) {
            return true;
        }

        protected override bool IsValidTarget(object target) {
            return target is Character;
        }
    }
}
