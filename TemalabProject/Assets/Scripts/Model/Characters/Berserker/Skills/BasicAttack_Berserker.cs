using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Berserker : EnemySkill {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly string description = "Deal 40 damage to a target unit.";

        private static readonly int damage = 40;
        private static readonly float animationDelay = 0.95f;

        public BasicAttack_Berserker() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            // Passive bonus
            int bonusDamage = calculateBonus(source);

            Result result = new Result(0, false);
            if (enemy.TryPhysicalDodge()) {
                enemy.OnDodge(0);
            }
            else {
                result = enemy.OnPhysicalDamage(damage + bonusDamage, animationDelay);
            }
            source.OnAttack(enemy);

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        private int calculateBonus(Character source) {
            int missingHealth = source.ConstStats.TotalHealth - source.GameStats.RemainingHealth;
            int bonus = missingHealth/15;
            return bonus;
        }

        public override double GetRange(Character source) {
            return 1;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            // TODO check range here
            return true;
        }

    }

}