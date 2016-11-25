using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Ranger : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly string description = "Deal 70 damage to a target unit.";

        private static readonly int damage = 70;
        private static readonly float animationDelay = 1.08f;

        public BasicAttack_Ranger() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            Result result = new Result();
            if (enemy.TryPhysicalDodge()) {
                enemy.OnDodge(0.5f);
            } else {
                result = enemy.OnPiercingDamage(damage, animationDelay);
            }

            source.OnAttack(enemy, "Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        public override float GetRange(Character source) {
            return 15;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target is Character;
        }

    }

}