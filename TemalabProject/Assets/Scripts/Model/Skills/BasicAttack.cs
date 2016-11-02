using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {
    public class BasicAttack : Skill {
        public override void Execute(Character source, Unit target) {
            if (!IsValidTarget(target)) {
                return;
            }

            Character enemy = target as Character;

            Result result = new Result();
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

        protected override bool IsValidTarget(Unit target) {
            return target is Character;
        }
    }
}
