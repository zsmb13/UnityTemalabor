using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class Lockdown : EnemySkill
    {

        //active attack specs.
        private static readonly int cooldown = 3;

        private static readonly string name = "Lockdown";
        private static readonly float range = -1.0f;
        private static readonly int enemycooldown = 3;
        private static readonly string description = String.Format("Increase the cooldown of a target unit by {0}.",enemycooldown);
        


        public Lockdown() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;
            //cooldown increasing
            enemy.GameStats.Cooldown += enemycooldown;

            source.TurnStats.ActionPoints--;
            source.TurnStats.ActiveAbilityUsed = true;
            source.Animate("Active");
        }

        public override float GetRange(Character source)
        {
            return range;
        }

        public override bool IsAvailable(TurnStats stats)
        {
            return stats.ActionPoints > 0;
        }

    }

}