using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Model;

namespace Assets.Scripts.UI {

    public class CharacterHoverHandler : MonoBehaviour {

        public InfoPanel leftPanel;
        private Transform movementRangeCircle;
        private Character character;

        void Start() {
            character = GetComponent<Character>();
            
            if(transform.Find("Team 1 UI") != null) {
                movementRangeCircle = transform.Find("Team 1 UI/Movement Range Circle");
            } else if(transform.Find("Team 2 UI") != null) {
                movementRangeCircle = transform.Find("Team 2 UI/Movement Range Circle");
            } else {
                throw new UnityException("Nincs UI gameobject!!");
            }

        }


        void OnMouseOver() {
            leftPanel.ShowInfo(character);

            float remainingMovement = character.TurnStats.RemainingMovement;
            if(remainingMovement < 0.5) {
                return;
            }

            movementRangeCircle.gameObject.SetActive(true);
            movementRangeCircle.localScale = new Vector3(remainingMovement * 2, remainingMovement * 2, 1);

        }

        void OnMouseExit() {
            leftPanel.Hide();
            movementRangeCircle.gameObject.SetActive(false);
        }

    }

}