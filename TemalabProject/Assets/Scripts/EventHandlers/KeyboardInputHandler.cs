using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts.Model.Skills {
    public class KeyboardInputHandler : MonoBehaviour {

        public CameraController cameraController;
        public Button endTurnButton1;
        public Button endTurnButton2;
        public Button skillButton0;
        public Button skillButton1;
        public Button skillButton2;


        private void PressButton(Button b) {
            if(b == null) return;
            b.onClick.Invoke();
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.C)) {
                cameraController.switchToNextCamera();
            }

            if(Input.GetKeyDown(KeyCode.O)) {
                cameraController.ToggleOrtographicCamera();
            }

            if(Input.GetKeyDown(KeyCode.D)) {
                PressButton(endTurnButton1);
            }

            if(Input.GetKeyDown(KeyCode.F)) {
                PressButton(endTurnButton2);
            }

            if(Input.GetKeyDown(KeyCode.Q)) {
                PressButton(skillButton0);
            }

            if(Input.GetKeyDown(KeyCode.W)) {
                PressButton(skillButton1);
            }

            if(Input.GetKeyDown(KeyCode.E)) {
                PressButton(skillButton2);
            }

        }


    }
}
