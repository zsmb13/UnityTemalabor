using UnityEngine;
using System.Collections.Generic;


namespace Assets.Scripts.Model {

    public class Player : MonoBehaviour {

        public TurnManager turnManager;
        public int teamID;
        public List<Character> characters;

        void Start() {
            foreach (var c in characters) {
                c.GameStats.Team = teamID;
            }
        }

        public void OnTurnEndButtonClicked() {
            Debug.Log("Player" + teamID + " turn end button clicked");
            turnManager.EndTurn(teamID);
        }

        public void OnTurnStart() {
            characters.RemoveAll(c => !c.gameObject.activeSelf);

            foreach (var c in characters) {
                c.OnTurnStart();
            }
        }

        public void OnTurnEnd() {
            foreach (var c in characters) {
                c.OnTurnEnd();
            }
        }

    }

}