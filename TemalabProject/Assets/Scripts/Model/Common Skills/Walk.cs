using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {
    public class Walk : Skill {
        public override void Execute(Character source, object target) {
            if(!IsValidTarget(target)) {
                return;
            }

            GameTerrain terrain = target as GameTerrain;
            NavMeshAgent agent = source.GetComponent<NavMeshAgent>();
            agent.SetDestination(terrain.LastClickPosition);
        }

        public override double GetRange() {
            return 10;
        }

        public override bool IsAvailable(TurnStats stats) {
            return true;
        }

        protected override bool IsValidTarget(object target) {
            return target is GameTerrain;
        }
    }
}
