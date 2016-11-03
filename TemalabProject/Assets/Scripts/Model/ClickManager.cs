using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {
    public class ClickManager : MonoBehaviour {

        private Character selected = null;

        public void ClickedOn(object clickTarget) {
            if(clickTarget is Character) {
                if(selected == null) {
                    selected = clickTarget as Character;
                }
                else {
                    selected.GiveTarget(clickTarget);
                    // TODO Remove later
                    RemoveSelected();
                }
            }
            else {
                if(selected != null) {
                    selected.GiveTarget(clickTarget);
                    // TODO Remove later
                    RemoveSelected();
                }
            }
        }

        public void RemoveSelected() {
            selected = null;
        }

    }
}
