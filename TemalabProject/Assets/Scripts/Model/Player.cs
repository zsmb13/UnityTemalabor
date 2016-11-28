using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public class Player : MonoBehaviour {

        private static readonly int maxDeployed = 6;

        public TurnManager turnManager;
        public int teamID;
        public List<Character> characters;

        private int deadCount = 0;
        private int deployedCount = 0;

        void Start() {
            foreach (var c in characters) {
                c.GameStats.Team = teamID;
                c.CharacterKilled += characterKilled;
            }
        }

        private void characterKilled(Character c) {
            deadCount++;

            if (deadCount == maxDeployed) {
                Debug.Log("Player " + teamID + " LOST the game because they're a loser.");
            }
        }

        public bool CanDeploy() {
            return deployedCount < maxDeployed;
        }

        public void OnTurnEndButtonClicked() {
            Debug.Log("Player" + teamID + " turn end button clicked");
            turnManager.EndTurn(teamID);
        }

        public void OnTurnStart() {
            //characters.RemoveAll(c => !c.gameObject.activeSelf);

            foreach (var c in characters) {
                c.OnTurnStart();
            }
        }

        public void OnTurnEnd() {
            deployedCount = 0;
            foreach (var c in characters) {
                c.OnTurnEnd();

                if (c.GameStats.Deployed) {
                    deployedCount++;
                }
            }
        }

    }

}