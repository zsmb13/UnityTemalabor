using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {

    public class Walk : MiscSkill {

        private static readonly int cooldown = 0;
        private static readonly string name = "Walk";
        private static readonly string description = "Moves the character on the battlefield.";

        public Walk() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            GameTerrain terrain = target as GameTerrain;

            float distance = (terrain.LastClickPosition - source.transform.position).magnitude;
            Debug.Log(distance + " " + source.TurnStats.RemainingMovement);
            if (distance > source.TurnStats.RemainingMovement) {
                return;
            }
            
            NavMeshAgent agent = source.GetComponent<NavMeshAgent>();
            agent.SetDestination(terrain.LastClickPosition);
            source.TurnStats.RemainingMovement -= distance;

            source.OnWalk();
            
        }

        public override float GetRange(Character source) {
            return source.TurnStats.RemainingMovement;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.RemainingMovement > 0.5;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return target is GameTerrain;
        }

    }

}