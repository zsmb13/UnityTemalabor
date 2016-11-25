using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Assassin : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly string description = "Deal 40 damage to a target unit.";

        private static readonly int damage = 40;
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

            source.OnAttack(enemy,"Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        public override float GetRange(Character source) {
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