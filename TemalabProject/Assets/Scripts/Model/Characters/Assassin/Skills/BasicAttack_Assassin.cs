using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Assassin : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly int damage = 70;
        private static readonly float range = 2.5f;
        private static readonly string description = String.Format("Deal {0} damage to a target unit.",damage);

        
        private static readonly float animationDelay = 1.08f;

        public BasicAttack_Assassin() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            Result result = new Result();
            if(enemy.TryPhysicalDodge()) {
                enemy.OnDodge(0);
            } else {
                result = enemy.OnPhysicalDamage(damage, animationDelay);
            }

            source.OnAttack(enemy, "Attack", 90.0f);

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;

            //TODO passive skills
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

    }

}