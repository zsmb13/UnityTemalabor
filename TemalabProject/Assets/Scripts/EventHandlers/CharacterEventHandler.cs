using UnityEngine;
using System.Collections;
using Assets.Scripts.Model;

public class CharacterEventHandler : MonoBehaviour {
    private Character character;    
    void Start() {
        character = GetComponent<Character>();
    }

    void OnMouseUp() {
        character.NotifyClicked();
    }
}
