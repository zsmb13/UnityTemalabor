﻿using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class Lockdown : EnemySkill
    {

        private static readonly int cooldown = 3; //TODO
        private static readonly string name = "Lockdown";

        private static readonly string description =
            String.Format(" Increase the cooldown of a target unit by {0}.", enemycooldown);

        private static readonly int enemycooldown = 3;

        public Lockdown() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;

            source.TurnStats.ActionPoints--;
            enemy.GameStats.Cooldown += enemycooldown;
            source.OnAttack(enemy, "Active");
        }

        public override float GetRange(Character source)
        {
            return 100;
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