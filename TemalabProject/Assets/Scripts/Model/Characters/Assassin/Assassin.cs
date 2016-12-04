using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Assassin : Character {

        bool passiveTriggeredThisRound = false;

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
            skills.Add(new Blink());

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

        public override void OnTurnStart() {
            base.OnTurnStart();
            passiveTriggeredThisRound = false;
        }

        public override void AfterAttack(Character target, Result result) {
            base.AfterAttack(target, result);
            tryBackstab(target);
        }

        private void tryBackstab(Character target) {
            if(passiveTriggeredThisRound) return;
            var sourcePos = this.gameObject.transform.position;
            var targetPos = target.gameObject.transform.position;

            Vector3 attackDir = Vector3.Normalize(targetPos - sourcePos);
            Vector3 enemyDir = target.transform.forward;

            if(Vector3.Dot(attackDir,enemyDir) > 0.7f) {
                this.TurnStats.ActionPoints++;
                passiveTriggeredThisRound = true;
            }
        }


    }

}