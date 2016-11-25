using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Model {

    public abstract class Skill {

        public int Cooldown { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Skill(string name, string description, int cooldown) {
            Name = name;
            Description = description;
            Cooldown = cooldown;
        }

        public void Execute(Character source, object target) {
            if (!IsAvailable(source.TurnStats)) {
                return;
            }

            if (!HasRequiredTeam(source, target)) {
                return; // invalid target team
            }

            if (!IsValidTarget(source, target)) {
                return;
            }

            if (!IsInRange(source, target)) {
                return;
            }

            OnExecute(source, target);

            // at this point, the skill must have executed successfully
            source.GameStats.Cooldown += Cooldown;
        }

        private bool IsInRange(Character source, object target) {
            float range = GetRange(source);
            if (range < 0) {
                return true;
            }

            Vector3 targetPos;
            if (target is Character) {
                targetPos = ((Character) target).gameObject.transform.position;
            }
            else {
                targetPos = ((GameTerrain) target).LastClickPosition;
            }

            Vector3 sourcePos = source.gameObject.transform.position;

            float diffX = targetPos.x - sourcePos.x;
            float diffZ = targetPos.z - sourcePos.z;

            //Debug.Log("Dist squared is " + (diffX*diffX+diffZ*diffZ));
            //Debug.Log("Range squared is " + (range*range));

            return diffX*diffX + diffZ*diffZ <= range*range;
        }

        public abstract float GetRange(Character source);

        protected abstract bool HasRequiredTeam(Character source, object target);

        public abstract bool IsAvailable(TurnStats turnStats);

        protected abstract bool IsValidTarget(Character source, object target);

        protected abstract void OnExecute(Character source, object target);

        public override string ToString() {
            return Name + ": " + Description;
        }

    }

}