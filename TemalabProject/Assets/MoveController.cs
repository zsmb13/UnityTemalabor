using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (GetComponent<TerrainCollider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            agent.SetDestination(hit.point);
        }
    }

}
