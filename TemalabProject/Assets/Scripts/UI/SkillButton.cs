using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEditor;

namespace Assets.Scripts.Model {

    public class SkillButton : MonoBehaviour {

        public ClickManager clickManager;
        private Skill skill;
        private Text label;

        void Start() {
            label = gameObject.GetComponentInChildren<Text>();
            //clickManager.characterSelectedEvent += OnCharacterSelection;
            //clickManager.characterDeselectedEvent += OnCharacterDeselection;
        }

        public void OnSkillButtonPressed() {
            Character c = clickManager.getSelectedCharacter();
            c.TurnStats.SelectedSkill = skill;
            Debug.Log("Új kijelölt skill: " + c.TurnStats.SelectedSkill);

            Setup(skill); // hide it if it's no longer available, etc.
        }

        public void Setup(Skill s) {
            // TODO check if skil is available
            TurnStats turnStats = clickManager.getSelectedCharacter().TurnStats;
            if (s.IsAvailable(turnStats)) {
                gameObject.SetActive(true);
                skill = s;
                label.text = s.Name;
            }
            else {
                Disable();
            }
        }

        public void Disable() {
            gameObject.SetActive(false);
            skill = null;
            label.text = "";
        }

    }

}