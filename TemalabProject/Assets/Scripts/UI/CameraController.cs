using UnityEngine;
using System.Collections;


public delegate void CameraEvent(Camera newCamera);


public class CameraController : MonoBehaviour {
    public event CameraEvent CameraChangedEvent;

    public Camera[] cameras;
    private int currentCameraIndex;

    // Use this for initialization
    void Start() {
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for(int i = 1; i < cameras.Length; i++) {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if(cameras.Length > 0) {
            cameras[0].gameObject.SetActive(true);
        }
    }

    public void switchToNextCamera() {
        currentCameraIndex++;
        Debug.Log("Switching to the next camera " + currentCameraIndex);
        if(currentCameraIndex < cameras.Length) {
            cameras[currentCameraIndex - 1].gameObject.SetActive(false);
            cameras[currentCameraIndex].gameObject.SetActive(true);
        } else {
            cameras[currentCameraIndex - 1].gameObject.SetActive(false);
            currentCameraIndex = 0;
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
        if(CameraChangedEvent != null) {
            CameraChangedEvent(getCurrentCamera());
        }
    }

    public Camera getCurrentCamera() {
        return cameras[currentCameraIndex];
    }
}