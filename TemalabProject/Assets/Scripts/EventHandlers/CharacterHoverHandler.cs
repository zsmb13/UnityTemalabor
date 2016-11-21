using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Model;

namespace Assets.Scripts.UI {

    public class CharacterHoverHandler : MonoBehaviour {

        public InfoPanel leftPanel;
        private Transform movementRangeCircle;

        void OnMouseOver() {
            Character character = GetComponent<Character>();
            leftPanel.ShowInfo(character);

            if (movementRangeCircle == null) {
                movementRangeCircle = transform.Find("Movement Range Circle");
            }

            float remainingMovement = character.TurnStats.RemainingMovement;
            if (remainingMovement < 0.5) {
                return;
            }

            movementRangeCircle.gameObject.SetActive(true);
            movementRangeCircle.localScale = new Vector3(remainingMovement*2, remainingMovement*2, 1);

        }

        void OnMouseExit() {
            leftPanel.Hide();
            movementRangeCircle.gameObject.SetActive(false);
        }

    }

}