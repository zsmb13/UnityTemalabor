using UnityEngine;
using System.Collections;
using Assets.Scripts.Model;

public class CharacterEventHandler : MonoBehaviour {

    public Animator animator;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        if (!agent.pathPending) {
            if (agent.remainingDistance <= agent.stoppingDistance) {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                    animator.SetBool("Moving", false);
                    return;
                }
            }
        }
        if (agent.hasPath) {
            animator.SetBool("Moving", true);
        }
    }

    void OnMouseUp() {
        //animator.SetTrigger("Attack");

        Character character = GetComponent<Character>();
        character.MyOnClick();
    }
}
