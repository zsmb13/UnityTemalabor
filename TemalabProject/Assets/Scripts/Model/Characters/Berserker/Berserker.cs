using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Characters {

    public class Berserker : Character {

        public void Awake() {
            ConstStats constStats = new ConstStats();
            // TODO use actual stats
            constStats.Name = "Gregor";
            constStats.CharacterType = "Berserker";
            constStats.DodgeChance = 10;
            constStats.MagicResist = 15;
            constStats.PhysicalResist = 5;
            constStats.TotalHealth = 300;
            constStats.TotalMovement = 5;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Berserker());
            skills.Add(new Charge());

            Init(constStats, skills);
        }

        protected override float GetDeathDelay() {
            return 0.2f;
        }

        protected override float GetDodgeDelay() {
            Debug.Log("Berserker dodge delay is missing");
            return 0;
        }

        protected override float GetDamagedDelay() {
            return 0.2f;
        }

    }

}