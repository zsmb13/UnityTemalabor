using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Model;
using UnityEngine;

namespace Assets.Scripts.Model.Skills {

    public class Hellfire : MiscSkill {

        private static readonly int cooldown = 3;
        private static readonly string name = "Hellfire";
        private static readonly int damage = 70;
        private static readonly float range = 4.0f;
        private static readonly string description = 
            String.Format("Hellfire: Ignites the cells around this character, dealing {0} magical damage to any enemy nearby.", 
                damage);
        
        private static readonly float animationDelay = 0.0f;

        public Hellfire() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {

            Result result = new Result();

            
            PlayerManager pm = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
            Player p = pm.GetPlayerByEnemyTeamID(source.GameStats.Team);
            List<Character> enemies = p.characters; 
            


            foreach(Character enemy in enemies) {
                if(!enemy.GameStats.Deployed) continue;
                if(!IsInRange(source, enemy)) continue;

                result = enemy.OnMagicDamage(damage, animationDelay);
                enemy.AfterDefense(source, result);
            }

            source.Animate("Active");

            source.TurnStats.ActionPoints--;
            source.TurnStats.ActiveAbilityUsed = true;

        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0 && !stats.ActiveAbilityUsed;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target == source;
        }

        


    }

}