using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public class ClickManager : MonoBehaviour {

        public TurnManager turnManager;

        public Character SelectedCharacter {
            get { return selected; }
            private set { selected = value; }
        }
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

                    SelectedCharacter = targetChar;
                    targetChar.Select();
                    //Selected event meghívása
                    if (characterSelectedEvent != null) {
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
            if (SelectedCharacter != null) {
                SelectedCharacter.Deselect();
            }
            SelectedCharacter = null;
        }

    }

}