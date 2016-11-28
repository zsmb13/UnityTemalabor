using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using System;

namespace Assets.Scripts.Model.Characters {

    public class Ranger : Character {

        public void Awake() {
            ConstStats constStats = new ConstStats();

            constStats.Name = "Julia";
            constStats.CharacterType = "Ranger";
            constStats.DodgeChance = 10;
            constStats.MagicResist = 0;
            constStats.PhysicalResist = 0;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 5.0f;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Ranger());
            // TODO: implement strafe
            skills.Add(new Walk());

            Init(constStats, skills);
        }

        protected override float GetDamagedDelay() {
            return 2;
        }

        protected override float GetDeathDelay() {
            return 2;
        }

        protected override float GetDodgeDelay() {
            return 2;
        }
    }
}