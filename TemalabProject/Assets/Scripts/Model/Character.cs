using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model {
    public class Character : MonoBehaviour, Unit {

        public ClickManager clickManager;

        ConstStats constStats;
        GameStats gameStats;
        TurnStats turnStats;

        Skill deploySkill;  
        List<Skill> skills = new List<Skill>();
    
        void Start() {
            turnStats = new TurnStats();
            turnStats.SelectedSkill = new Walk();
        }

        public void Init(int team, ConstStats stats) {
            this.constStats = stats;
            this.gameStats.Team = team;
        }

        public void GiveTarget(Unit target) {
            turnStats.SelectedSkill.Execute(this, target);
        }

        public void MyOnClick() {
            clickManager.ClickedOn(this);
        }

    }
}
