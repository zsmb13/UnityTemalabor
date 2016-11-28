using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Assassin : Character {

        public void Awake() {
            var constStats = new ConstStats();

            constStats.Name = "Clementine";
            constStats.CharacterType = "Assassin";
            constStats.DodgeChance = 30;
            constStats.MagicResist = 10;
            constStats.PhysicalResist = 0;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 12.0f;

            var skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Assassin());
            skills.Add(new BlinkTest()); // TODO remove, miért?

            Init(constStats, skills);
        }

        protected override float GetDeathDelay() {
            return 0.08f;
        }

        protected override float GetDodgeDelay() {
            return 0.0f;
        }

        protected override float GetDamagedDelay() {
            return 0.4f;
        }

    }

}