using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    public Transform MyCameraTransform;
    private Transform MyTransform;

    // Use this for initialization
    void Start() {
        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate() {
        MyTransform.forward = MyCameraTransform.forward;
    }
}
