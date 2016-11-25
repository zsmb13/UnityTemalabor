using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
    
    private CameraController cameraController;
    private Transform MyCameraTransform;
    private Transform MyTransform;
    
    void Start() {
        MyTransform = this.transform;
        cameraController = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraController>();
        MyCameraTransform = cameraController.getCurrentCamera().transform;
        cameraController.CameraChangedEvent += CameraChangedCallback;
    }
    
    void LateUpdate() {
        MyTransform.forward = MyCameraTransform.forward;
    }

    void CameraChangedCallback(Camera newCamera) {
        MyCameraTransform = newCamera.transform;
    }
}
