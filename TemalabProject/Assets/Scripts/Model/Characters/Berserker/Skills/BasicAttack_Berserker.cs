using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class BasicAttack_Berserker : Skill {

        private int damage = 50;

        public BasicAttack_Berserker() {
            cooldown = 2;
            name = "Basic attack";
            description = String.Format("Deal {0} damage to a target unit.", damage);
        }

        public override void Execute(Character source, object target) {
            if(!IsValidTarget(target)) {
                return;
            }
            Character enemy = target as Character;

            Result result = new Result(0, false);
            if(enemy.TryPhysicalDodge()) {
                enemy.OnDodge(0);
            } else {
                result = enemy.OnPhysicalDamage(damage, 0);
            }
            source.OnAttack(enemy);
            // afterattack
            // afterdefense
            
        }

        public override double GetRange(Character source) {
            return 1;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return true;
        }

        protected override bool IsValidTarget(object target) {
            return target is Character;
        }
    }
}