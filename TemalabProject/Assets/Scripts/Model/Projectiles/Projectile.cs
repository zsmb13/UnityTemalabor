using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private bool launched = false;

    void Start() {
        GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void FixedUpdate() {
        if (launched) {
            transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
        }
    }

    public void Launch(Vector3 target, float angle, float delay) {

        Vector3 pos = transform.position;

        float dist = Vector3.Distance(pos, target);
        //dist is larger than should if the y coordinates are not the same
        dist -= Mathf.Abs(pos.y - target.y);

        transform.LookAt(target);

        float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * angle * 2)));
        float Vy, Vz;

        Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * angle);
        Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * angle);

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);

        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        StartCoroutine(startProjectile(globalVelocity, delay));

    }

    private IEnumerator startProjectile(Vector3 velocity, float delay) {
        yield return new WaitForSecondsRealtime(delay);
        GetComponent<Rigidbody>().useGravity = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        launched = true;
        GetComponent<Rigidbody>().velocity = velocity;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Terrain")) {
            Destroy(gameObject);
        }
    }

}
