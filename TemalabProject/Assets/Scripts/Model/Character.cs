using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using System;

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
            turnStats.SelectedSkill = new BasicAttack();

            constStats = new ConstStats();

            // Random stats for testing
            constStats.DodgeChance = 0;
            constStats.MagicResist = 1;
            constStats.PhysicalResist = 2;
            constStats.TotalHealth = 3;
            constStats.TotalMovement = 4;
        }

        public ConstStats GetConstStats()
        {
            return constStats;
        }

        public void OnDodge(int animationDelay) {
            Animator animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
            animator.SetTrigger("Dodge");
        }

        public Result OnMagicDamage(int damage, int animationDelay) {
            Animator animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
            animator.SetTrigger("Damaged");
            // health -= damage
            // if(health <= 0) SetTrigger("Death");
            // etc...
            Result result = new Result();
            result.DamageDone = damage;
            result.Killed = false;
            return result;
        }

        public void OnAttack() {
            Animator animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
            animator.SetTrigger("Attack");
        }

        public bool TryPhysicalDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return constStats.DodgeChance >= rand;
        }
    
        public bool TryMagicDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return constStats.DodgeChance >= rand;
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
