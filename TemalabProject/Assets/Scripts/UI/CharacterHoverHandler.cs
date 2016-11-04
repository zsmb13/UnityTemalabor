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
            Skill selectedSkill = character.TurnStats.SelectedSkill;
            infoPanel.ShowConstInfo(constStats.ToString(), selectedSkill.ToString());
        }

        void OnMouseExit()
        {
            infoPanel.Hide();
        }
    }
}
