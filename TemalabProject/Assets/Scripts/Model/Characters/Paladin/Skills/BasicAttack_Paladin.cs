using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills
{

    public class BasicAttack_Paladin : EnemySkill
    {

        private static readonly int cooldown = 2;
        private static readonly string name = "Basic attack";
        private static readonly int damage = 60;
        private static readonly float range = 2.5f;
        private static readonly string description = String.Format("Deal {0} damage to a target unit.", damage);
        //Passive description missing

        private static readonly float animationDelay = 1.0f; //TODO

        public BasicAttack_Paladin() : base(name, description, cooldown) { }

        protected override void OnExecute(Character source, object target)
        {
            Character enemy = target as Character;

            Result result = new Result();
            if (enemy.TryPhysicalDodge())
            {
                enemy.OnDodge(0);
            }
            else
            {
                result = enemy.OnPhysicalDamage(damage, animationDelay);
            }
            source.OnAttack(enemy, "Attack");

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }


        public override float GetRange(Character source)
        {
            return range;
        }

        public override bool IsAvailable(TurnStats turnStats)
        {
            return turnStats.ActionPoints > 0;
        }

    }

}