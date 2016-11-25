using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model {
    public class TerrainEventHandler : MonoBehaviour {
        
        public CameraController cameraController;

        void OnMouseUp() {
            RaycastHit hit;
            Camera camera = cameraController.getCurrentCamera();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (GetComponent<TerrainCollider>().Raycast(ray, out hit, Mathf.Infinity)) {
                GameTerrain terrain = GetComponent<GameTerrain>();
                terrain.NotifyClicked(hit.point);
            }
        }

    }
}
