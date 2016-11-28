using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Pyromancer : Character {

        public void Awake() {
            var constStats = new ConstStats();

            constStats.Name = "Kyra";
            constStats.CharacterType = "Pyromancer";
            constStats.DodgeChance = 0;
            constStats.MagicResist = 15;
            constStats.PhysicalResist = 5;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 8.0f;

            var skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Pyromancer());
            //todo implement hellfire
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