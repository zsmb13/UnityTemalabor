using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Skills {
    class BasicAttack_Priest : EnemySkill {

        private static readonly int cooldown = 1;
        private static readonly string name = "Basic attack";
        private static readonly int damage = 50;
        private static readonly float range = 15.0f;
        private static readonly string description = String.Format("Deal {0} magical damage to a target unit.",damage);
                
        private static readonly float animationDelay = 1.58f;

        public BasicAttack_Priest() : base(name, description, cooldown) {}

        //TODO divine blessing?
        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            Result result = new Result();
            if (enemy.TryMagicDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnMagicDamage(damage, animationDelay);
            }

            source.OnAttack(enemy, "Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }
    }
}
