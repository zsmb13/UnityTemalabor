using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Model;

namespace Assets.Scripts.UI {

    public class CharacterHoverHandler : MonoBehaviour {

        public InfoPanel leftPanel;

        void OnMouseOver() {
            Character character = GetComponent<Character>();
            leftPanel.ShowInfo(character);
        }

        void OnMouseExit() {
            leftPanel.Hide();
        }

    }

}