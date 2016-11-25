using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class BasicAttack_Paladin : EnemySkill
    {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly string description = "Deal 50 damage to a target unit.";

        private static readonly int damage = 50;
        private static readonly float animationDelay = 1.0f; //TODO

        public BasicAttack_Paladin() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;

            //Passive missing

            Result result = new Result();
            if (enemy.TryPhysicalDodge())
            {
                enemy.OnDodge(0);
            }
            else
            {
                result = enemy.OnPhysicalDamage(damage, animationDelay);
            }
            source.OnAttack(enemy,"Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }


        public override float GetRange(Character source)
        {
            return 2.5f;
        }

        public override bool IsAvailable(TurnStats turnStats)
        {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target)
        {
            return true;
        }

    }

}