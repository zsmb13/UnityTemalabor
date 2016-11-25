using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
    
    public CameraController cameraController;
    private Transform MyCameraTransform;
    private Transform MyTransform;
    
    void Start() {
        MyTransform = this.transform;
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
