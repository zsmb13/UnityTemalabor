using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Pyromancer : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly int damage = 60;
        private static readonly float range = 6.0f;
        private static readonly string description = String.Format("Deal {0} damage to a target unit.",damage);

        
        private static readonly float animationDelay = 1.08f;

        public BasicAttack_Pyromancer() : base(name, description, cooldown) {}

        //TODO passive skills
        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            Result result = new Result();
            if (enemy.TryMagicDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnMagicDamage(damage, animationDelay);
            }

            source.OnAttack(enemy,"Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

    }

}