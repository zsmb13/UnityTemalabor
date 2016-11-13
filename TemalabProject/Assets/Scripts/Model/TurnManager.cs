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
            player1.OnTurnStart();
        }

        public void EndTurn(int teamID) {
            if (CurrentTeam != teamID) {
                Debug.Log("That team can't end the current turn");
                return;
            }

            clickmanager.RemoveSelected();

            if (CurrentTeam == 1) {
                player1.OnTurnEnd();
                CurrentTeam = 2;
                player2.OnTurnStart();
            }
            else {
                player2.OnTurnEnd();
                CurrentTeam = 1;
                player1.OnTurnStart();
            }
        }

    }

}