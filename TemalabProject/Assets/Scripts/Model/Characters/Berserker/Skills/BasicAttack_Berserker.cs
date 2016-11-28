using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Berserker : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly int damage = 60;
        private static readonly float range = 2.5f;

        private static readonly string description =
            "Deal 60 damage to a target unit. Below 40% health, this character can attack twice";

        private static readonly float animationDelay = 0.95f;

        public BasicAttack_Berserker() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            // Passive bonus
            int bonusDamage = calculateBonus(source);

            Result result = new Result();
            if (enemy.TryPhysicalDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnPhysicalDamage(damage + bonusDamage, animationDelay);
            }
            source.OnAttack(enemy, "Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        private int calculateBonus(Character source) {
            int missingHealth = source.ConstStats.TotalHealth - source.GameStats.RemainingHealth;
            int bonus = missingHealth/15;
            return bonus;
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

    }

}