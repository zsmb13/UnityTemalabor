using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model;

public class SkillBar : MonoBehaviour {

    public ClickManager clickManager;
    private SkillButton[] buttons;

    void Awake() {
        buttons = gameObject.transform.GetComponentsInChildren<SkillButton>();
        Debug.Log("Found " + buttons.Length + " children");

        clickManager.characterSelectedEvent += OnCharacterSelection;
        clickManager.characterDeselectedEvent += OnCharacterDeselection;
        clickManager.characterSkillExecutedEvent += OnCharacterSelection; // same handler, re-init buttons
    }
    
    public void OnCharacterSelection(Character c) {
        List<Skill> skills = c.GetSkills();
        if (skills.Count > buttons.Length) {
            Debug.Log("Not enough buttons(" + buttons.Length + ") to display skills(" + skills.Count + ")");
        }

        for (int i = 0; i < skills.Count; i++) {
            buttons[i].Setup(skills[i]);
        }
    }

    public void OnCharacterDeselection(Character c) {
        foreach (var b in buttons) {
            b.Disable();
        }
    }

}
