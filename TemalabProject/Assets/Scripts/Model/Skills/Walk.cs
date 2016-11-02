using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {
    public class Walk : Skill {
        public override void Execute(Character source, Unit target) {
            if(!IsValidTarget(target)) {
                return;
            }

            MyTerrain terrain = target as MyTerrain;
            NavMeshAgent agent = source.GetComponent<NavMeshAgent>();
            agent.SetDestination(terrain.lastClickPosition);
        }

        public override double GetRange() {
            return 10;
        }

        public override bool IsAvailable(TurnStats stats) {
            return true;
        }

        protected override bool IsValidTarget(Unit target) {
            return target is MyTerrain;
        }
    }
}
