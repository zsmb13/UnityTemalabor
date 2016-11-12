﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {
    public class Walk : Skill {

        public Walk() {
            cooldown = 0;
            name = "Walk";
            description = "Moves the character on the battlefield.";

        }

        public override void Execute(Character source, object target) {
            if(!IsValidTarget(target)) {
                return;
            }

            GameTerrain terrain = target as GameTerrain;

            float distance = (terrain.LastClickPosition - source.transform.position).magnitude;
            Debug.Log(distance + " " + source.TurnStats.RemainingMovement);
            if (distance > source.TurnStats.RemainingMovement) {
                return;
            }

            NavMeshAgent agent = source.GetComponent<NavMeshAgent>();
            agent.SetDestination(terrain.LastClickPosition);
            source.TurnStats.RemainingMovement -= distance;

        }

        public override double GetRange(Character source) {
            return source.TurnStats.RemainingMovement;
        }

        public override bool IsAvailable(TurnStats stats) {
            
            return stats.RemainingMovement>0.1;
        }

        protected override bool IsValidTarget(object target) {
            return target is GameTerrain;
        }
    }
}
