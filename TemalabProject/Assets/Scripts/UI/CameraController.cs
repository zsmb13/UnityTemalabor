using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
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
            //Debug.Log("Camera with name: " + cameras[0].camera.name + ", is now enabled");
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
    }

    public Camera getCamera() {
        return cameras[currentCameraIndex];
    }

}