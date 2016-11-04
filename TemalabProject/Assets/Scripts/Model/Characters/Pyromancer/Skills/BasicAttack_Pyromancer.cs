using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {
    public class BasicAttack_Pyromancer : Skill {

        private int damage = 30;

        public BasicAttack_Pyromancer() {
            cooldown = 2;
            name = "Basic attack";
            description = String.Format("Deal {0} damage to a target unit.", damage);
            
        }

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
                result = enemy.OnMagicDamage(damage, 0);
            }

            source.OnAttack(enemy);

            // afterattack
            // afterdefense
        }

        public override double GetRange(Character source) {
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
