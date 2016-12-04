using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model {

    public class TurnManager : MonoBehaviour {

        public PlayerManager playerManager;
        public ClickManager clickmanager;

        private int current;

        public int CurrentTeam {
            get { return current; }
            private set { current = value; }
        }

        void Start() {
            CurrentTeam = 1;
            playerManager.GetPlayerByTeamID(CurrentTeam).OnTurnStart();
        }

        public void EndTurn(int teamID) {
            if (CurrentTeam != teamID) {
                Debug.Log("That team can't end the current turn");
                return;
            }

            clickmanager.RemoveSelected();

            playerManager.GetPlayerByTeamID(CurrentTeam).OnTurnEnd();
            ChangeCurrentTeam();
            playerManager.GetPlayerByTeamID(CurrentTeam).OnTurnStart();
        }

        private void ChangeCurrentTeam() {
            CurrentTeam = (CurrentTeam == 1) ? 2 : 1;
        }

        public void OnTeamFallen(int teamID) {
            playerManager.GetPlayerByEnemyTeamID(teamID).OnWinTheGame();
        }

    }

}