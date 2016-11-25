using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Skills {
    class BasicAttack_Priest : EnemySkill {

        private static readonly int cooldown = 1;
        private static readonly string name = "Basic attack";
        private static readonly string description = "Deal 50 magical damage to a target unit.";

        private static readonly int damage = 50;
        private static readonly float animationDelay = 1.58f;

        public BasicAttack_Priest() : base(name, description, cooldown) {}

        public override float GetRange(Character source) {
            return 15f;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return true;
        }

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

    }
}
