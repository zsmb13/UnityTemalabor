using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Pyromancer : Character {

        public void Awake() {
            var constStats = new ConstStats();
            // TODO use actual stats
            constStats.Name = "Kyra";
            constStats.CharacterType = "Pyromancer";
            constStats.DodgeChance = 50; // TODO use real value, 50 is for testing
            constStats.MagicResist = 15;
            constStats.PhysicalResist = 15;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 5;

            var skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Pyromancer());
            skills.Add(new Walk());

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