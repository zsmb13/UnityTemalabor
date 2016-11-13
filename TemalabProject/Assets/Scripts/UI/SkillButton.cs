using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Assets.Scripts.Model {
    public class SkillButton : MonoBehaviour {

        public ClickManager clickManager;
        public Skill skill { get; set; }
        public int skillButtonNumber;

        
        void Start() {
            clickManager.characterSelectedEvent += OnCharacterSelection;
            clickManager.characterDeselectedEvent += OnCharacterDeselection;
        }

        public void OnSkillButtonPressed() {
            Character c = clickManager.getSelectedCharacter();
            c.TurnStats.SelectedSkill=skill;
            Debug.Log("Új kijelölt skill: " + c.TurnStats.SelectedSkill);
        }

        public void OnCharacterSelection(Character c) {
            try {
                skill = c.Skills[skillButtonNumber];
                gameObject.GetComponentInChildren<Text>().text = skill.name;
                gameObject.SetActive(true);
            }
            catch (ArgumentOutOfRangeException) {
                Debug.Log("Nincsen ennyiedik skill: " + skillButtonNumber);
            }

        }


        public void OnCharacterDeselection(Character c) {
            gameObject.SetActive(false);
            skill = null;
            gameObject.GetComponentInChildren<Text>().text = "";
            //Debug.Log("asd");
        }

    }
}