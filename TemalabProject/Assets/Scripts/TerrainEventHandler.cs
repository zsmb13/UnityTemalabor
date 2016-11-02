﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model {
    public class TerrainEventHandler : MonoBehaviour {

        public NavMeshAgent agent;

        void OnMouseUp() {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (GetComponent<TerrainCollider>().Raycast(ray, out hit, Mathf.Infinity)) {
                //agent.SetDestination(hit.point);

                MyTerrain terrain = GetComponent<MyTerrain>();
                terrain.MyOnClick(hit.point);
            }
        }

    }
}
