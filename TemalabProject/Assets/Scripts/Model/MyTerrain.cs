using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class MyTerrain : MonoBehaviour, Unit {

        public Vector3 lastClickPosition;

        public ClickManager clickManager;

        public void MyOnClick(Vector3 position) {
            this.lastClickPosition = position;
            clickManager.ClickedOn(this);
        }

    }
}
