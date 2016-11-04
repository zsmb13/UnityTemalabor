﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Model.Skills {
    public class Deploy : Skill {

        public Deploy() {
            cooldown = 0;
            name = "Deploy";
            description = "Deploys the character to the battlefield.";
        }

        public override void Execute(Character source, object target) {
            if (!IsValidTarget(target)) {
                return;
            }

            GameTerrain gameTerrain = target as GameTerrain;
            Vector3 targetPosition = gameTerrain.LastClickPosition;

            Transform transform = source.gameObject.transform;
            transform.position = new Vector3(
                targetPosition.x,
                transform.position.y,
                targetPosition.z
            );

            source.GameStats.Deployed = true;
        }

        public override double GetRange(Character source) {
            return 10;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return true;
        }

        protected override bool IsValidTarget(object target) {
            return target is GameTerrain;
        }
    }
}
