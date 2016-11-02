using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {
    public class ClickManager : MonoBehaviour {

        private Character selected = null;

        public void ClickedOn(Unit unit) {
            if(unit is Character) {
                if(selected == null) {
                    selected = unit as Character;
                }
                else {
                    selected.GiveTarget(unit);
                    // TODO Remove later
                    RemoveSelected();
                }
            }
            else {
                if(selected != null) {
                    selected.GiveTarget(unit);
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
