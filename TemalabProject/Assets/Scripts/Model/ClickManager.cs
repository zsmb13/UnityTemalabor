using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public class ClickManager : MonoBehaviour {

        public TurnManager turnManager;
        private Character selected = null;

        public delegate void characterSelectionStatusChange(Character character);
        public event characterSelectionStatusChange characterSelectedEvent;
        public event characterSelectionStatusChange characterDeselectedEvent;

        public void ClickedOn(object clickTarget) {
            if (clickTarget is Character) {
                var targetChar = (Character) clickTarget;
                
                if (targetChar.GameStats.Team != turnManager.CurrentTeam) {
                    return;
                }

                if (selected == null) {
                    selected = targetChar;
                    //Selected event meghívása
                    if(characterSelectedEvent != null) {
                        characterSelectedEvent(selected);
                    }
                }
                else {
                    selected.GiveTarget(targetChar);
                }
            }
            else {
                if (selected != null) {
                    selected.GiveTarget(clickTarget);
                }
            }
        }

        public void RemoveSelected() {
            characterDeselectedEvent(selected);
            selected = null;
        }

        public Character getSelectedCharacter() {
            return selected;//TODO jobban?
        }

    }

}