using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class Lockdown : EnemySkill
    {

        //active attack specs.
        private static readonly int cooldown = 4;
        private static readonly string name = "Lockdown";
        private static readonly string description = "Increase the cooldown of a target unit by 3.";
        private static readonly int enemycooldown = 3;


        public Lockdown() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;

            //cooldown increasing
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

    }

}