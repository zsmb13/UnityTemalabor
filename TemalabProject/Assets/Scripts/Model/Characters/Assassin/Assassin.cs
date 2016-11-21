using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Assassin : Character {

        public void Awake() {
            var constStats = new ConstStats();
            // TODO use actual stats
            constStats.Name = "Clementine";
            constStats.CharacterType = "Assassin";
            constStats.DodgeChance = 30;
            constStats.MagicResist = 15;
            constStats.PhysicalResist = 10;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 7;

            var skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Assassin());
            skills.Add(new BlinkTest()); // TODO remove

            Init(constStats, skills);
        }

        protected override float GetDeathDelay() {
            return 0.08f;
        }

        protected override float GetDodgeDelay() {
            return 0.98f;
        }

        protected override float GetDamagedDelay() {
            return 0.4f;
        }

    }

}