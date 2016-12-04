using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Characters {

    public class Ranger : Character {

        public GameObject projectile;
        public Transform projectileSpawn;

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
            skills.Add(new BasicAttack_Ranger(projectile, projectileSpawn));
            // TODO: implement strafe
            skills.Add(new Strafe(projectile, projectileSpawn));

            Init(constStats, skills);
        }

        protected override float GetDamagedDelay() {
            return 0.2f;
        }

        protected override float GetDeathDelay() {
            return 0.2f;
        }

        protected override float GetDodgeDelay() {
            return 0.2f;
        }
    }
}