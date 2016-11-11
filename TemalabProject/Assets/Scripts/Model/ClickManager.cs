using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public class ClickManager : MonoBehaviour {

        public TurnManager turnManager;
        private Character selected = null;

        public void ClickedOn(object clickTarget) {
            if (clickTarget is Character) {
                var targetChar = (Character) clickTarget;
                
                if (targetChar.GameStats.Team != turnManager.CurrentTeam) {
                    return;
                }

                if (selected == null) {
                    selected = targetChar;
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
            selected = null;
        }

    }

}