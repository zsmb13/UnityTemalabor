using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Characters {

    public class Priest : Character {

        public void Awake() {
            var constStats = new ConstStats {
                Name = "Wilhelm",
                CharacterType = "Priest",
                DodgeChance = 0,
                MagicResist = 15,
                PhysicalResist = 0,
                TotalHealth = 200,
                TotalMovement = 3
            };

            var skills = new List<Skill> {
                new Walk(),
                new BasicAttack_Priest(),
                new Restoration()
            };

            Init(constStats, skills);
        }

        protected override float GetDodgeDelay() {
            return 0;
        }

        protected override float GetDamagedDelay() {
            return 0.22f;
        }

        protected override float GetDeathDelay() {
            return 0.27f;
        }

        public override void AfterDefense(Character source, Result result) {
            if (result.DamageDone > 0 && result.DamageType == Result.MagicDamage) {
                source.OnMagicDamage(result.DamageDone, 0);
            }
        }

    }

}