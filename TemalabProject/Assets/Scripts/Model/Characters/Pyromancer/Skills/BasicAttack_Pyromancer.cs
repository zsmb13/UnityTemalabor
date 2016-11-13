using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Pyromancer : EnemySkill {

        private int damage = 40;

        public BasicAttack_Pyromancer() {
            cooldown = 2;
            name = "Basic attack";
            description = String.Format("Deal {0} damage to a target unit.", damage);
        }

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            Result result = new Result(0, false);
            if (enemy.TryMagicDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnMagicDamage(damage, 0);
            }

            source.OnAttack(enemy);

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        public override double GetRange(Character source) {
            return 10;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            // TODO check range here
            return true;
        }

    }

}