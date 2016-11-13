using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class GameTerrain : MonoBehaviour {

        public Vector3 LastClickPosition { get; set; }

        public ClickManager clickManager;

        public void NotifyClicked(Vector3 position) {
            LastClickPosition = position;
            clickManager.ClickedOn(this);
        }

    }
}
