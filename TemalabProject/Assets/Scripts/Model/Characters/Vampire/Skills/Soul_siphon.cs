using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class SoulSiphon : EnemySkill
    {
        //active attack specs.
        private static readonly int cooldown = 4;
        private static readonly string name = "Soul siphon";
        
        private static readonly int enemycooldown = 1;
        private static readonly int damage = 60;
        private static readonly float animationDelay = 1.0f; //TODO

        private static readonly string description =
            String.Format("Deal {0} magic damage to a single target unit and increase its cooldown by {1}.", damage, enemycooldown);

        public SoulSiphon() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;

            //Damage
            Result result = new Result();
            if (enemy.TryMagicDodge())
            {
                enemy.OnDodge(0);
            }
            else
            {
                result = enemy.OnMagicDamage(damage, animationDelay);
            }
            source.OnAttack(enemy, "Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);
           
            //cooldown increase
            enemy.GameStats.Cooldown += enemycooldown;

            source.TurnStats.ActionPoints--;
            source.TurnStats.ActiveAbilityUsed = true;
        }

        public override float GetRange(Character source)
        {
            return 2.5f;
        }

        public override bool IsAvailable(TurnStats stats)
        {
            return stats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target)
        {
            // TODO check range here
            return true;
        }

    }

}