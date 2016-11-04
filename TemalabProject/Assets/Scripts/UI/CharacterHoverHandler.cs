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

            string infosToShow = "";
            infosToShow += constStats.ToString() + "\n";
            infosToShow += "______________\n";
            infosToShow += character.DeploySkill.ToString()+"\n";
            infosToShow += "______________\n";
            foreach(Skill s in character.Skills) {
                infosToShow += s.ToString()+"\n";
                infosToShow += "______________\n";
            }

            infoPanel.ShowInfo(infosToShow);


        }

        void OnMouseExit()
        {
            infoPanel.Hide();
        }
    }
}
