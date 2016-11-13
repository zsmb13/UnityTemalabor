using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public class ClickManager : MonoBehaviour {

        public TurnManager turnManager;
        private Character selected = null;

        public delegate void CharacterEvent(Character character);

        public event CharacterEvent characterSelectedEvent;
        public event CharacterEvent characterDeselectedEvent;
        public event CharacterEvent characterSkillExecutedEvent;

        public void ClickedOn(object clickTarget) {
            if (clickTarget is Character) {
                var targetChar = (Character) clickTarget;
                
                if (selected == null) {
                    if (targetChar.GameStats.Team != turnManager.CurrentTeam) {
                        return;
                    }
                    if (targetChar.GameStats.Cooldown > 0) {
                        Debug.Log("That character is on Cooldown and can not be selected");
                        return;
                    }

                    selected = targetChar;
                    //Selected event meghívása
                    if(characterSelectedEvent != null) {
                        characterSelectedEvent(selected);
                    }
                }
                else {
                    selected.GiveTarget(targetChar);
                    if (characterSkillExecutedEvent != null) {
                        characterSkillExecutedEvent(selected);
                    }
                }
            }
            else {
                if (selected != null) {
                    selected.GiveTarget(clickTarget);
                    if (characterSkillExecutedEvent != null) {
                        characterSkillExecutedEvent(selected);
                    }
                }
            }
        }

        public void RemoveSelected() {
            if (characterDeselectedEvent != null) {
                characterDeselectedEvent(selected);
            }
            selected = null;
        }

        public Character getSelectedCharacter() {
            return selected;//TODO jobban?
        }

    }

}