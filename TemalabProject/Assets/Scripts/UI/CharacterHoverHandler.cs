using UnityEngine;
using System.Collections;
using Assets.Scripts.Model;

namespace Assets.Scripts.UI {
    public class CharacterHoverHandler : MonoBehaviour {

        public InfoPanel infoPanel;

        void OnMouseOver()
        {
            Character character = GetComponent<Character>();
            ConstStats constStats = character.ConstStats;
            infoPanel.ShowConstInfo(constStats.ToString());
        }

        void OnMouseExit()
        {
            infoPanel.Hide();
        }
    }
}
