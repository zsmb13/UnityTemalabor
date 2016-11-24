using UnityEngine;
using System.Collections;
using Assets.Scripts.Model;

public class CharacterEventHandler : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent agent;
    private Character character;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update() {
        if(!character.GameStats.Deployed) return;

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
        character.NotifyClicked();
    }
}
