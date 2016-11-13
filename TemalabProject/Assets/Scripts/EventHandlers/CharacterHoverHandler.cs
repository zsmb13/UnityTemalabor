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

            // TODO túl kicsi range (1> ?) esetén ne mutassa

            movementRangeCircle.gameObject.SetActive(true);
            float remainingMovement = character.TurnStats.RemainingMovement;
            movementRangeCircle.localScale = new Vector3(remainingMovement, remainingMovement, 1);

        }

        void OnMouseExit() {
            leftPanel.Hide();
            movementRangeCircle.gameObject.SetActive(false);
        }

    }

}