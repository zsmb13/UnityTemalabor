using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model {

    public class TurnManager : MonoBehaviour {

        public Player player1;
        public Player player2;
        public ClickManager clickmanager;

        private int current;

        public int CurrentTeam {
            get { return current; }
            private set { current = value; }
        }

        void Start() {
            CurrentTeam = 1;
            StartTurn();
        }

        public void EndTurn(int teamID) {
            if (CurrentTeam != teamID) {
                Debug.Log("That team can't end the current turn");
                return;
            }

            CurrentTeam = (CurrentTeam == 1 ? 2 : 1);

            player1.OnTurnEnd();
            player2.OnTurnEnd();

            StartTurn();
        }

        private void StartTurn() {
            clickmanager.RemoveSelected();
            player1.OnTurnStart();
            player2.OnTurnStart();
        }

    }

}