using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Model.Skills {
    public class Deploy : MiscSkill {

        private static readonly int cooldown = 0;
        private static readonly string name = "Deploy";
        private static readonly string description = "Deploys the character to the battlefield.";

        public Deploy() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            GameTerrain gameTerrain = target as GameTerrain;
            Vector3 targetPosition = gameTerrain.LastClickPosition;

            Transform transform = source.gameObject.transform;
            transform.position = new Vector3(
                targetPosition.x,
                transform.position.y,
                targetPosition.z
            );

            source.TurnStats.ActionPoints--;
            source.TurnStats.RemainingMovement = 0;
            source.GameStats.Deployed = true;
        }

        public override float GetRange(Character source) {
            return 10;
        }

        public override bool IsAvailable(TurnStats turnStats) {
            return turnStats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            if (source.GameStats.Deployed || !(target is GameTerrain)) {
                return false;
            }

            int team = source.GameStats.Team;

            var pos = ((GameTerrain) target).LastClickPosition;

            if (team == 1) {
                return IsInRect(0, 0, 7.5f, 15f, pos.x, pos.y);
            }
            else {
                return IsInRect(17.5f, 0, 25f, 15f, pos.x, pos.y);
            }
        }

        private bool IsInRect(float x1, float y1, float x2, float y2, float x, float y) {
            return x1 <= x && x <= x2 && y1 <= y && y <= y2;
        }

    }
}
