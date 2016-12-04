using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Model {

    public class PlayerManager : MonoBehaviour {
        public Player player1;
        public Player player2;

        public Player GetPlayerByTeamID(int teamID) {
            return teamID == 1 ? player1 : player2;
        }

        public Player GetPlayerByEnemyTeamID(int enemyTeamID) {
            return enemyTeamID == 1 ? player2 : player1;
        }

    }

}