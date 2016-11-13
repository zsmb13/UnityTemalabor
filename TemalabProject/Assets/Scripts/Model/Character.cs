using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model {
    public abstract class Character : MonoBehaviour {

        public ClickManager clickManager;

        public ConstStats ConstStats { get; set; }
        public GameStats GameStats { get; set; }
        public TurnStats TurnStats { get; set; }

        public Skill DeploySkill { get; set; }
        public List<Skill> Skills { get; set; }

        private Animator animator;
        private GameObject selectionCircle;

        public virtual void Start() {
            animator = gameObject.transform.GetComponent<Animator>();
        }

        public void AfterAttack(Character target, Result result) {
            // empty
        }

        public void AfterDefense(Character source, Result result) {
            // empty
        }

        public List<Skill> GetSkills() {
            List<Skill> skills = new List<Skill>();

            if (GameStats.Deployed) {
                // TODO make sure only the proper skills are active somewhere
                skills.AddRange(Skills);
            }
            else {
                skills.Add(DeploySkill);
            }

            return skills;
        }

        public void GiveTarget(object target) {
            TurnStats.SelectedSkill.Execute(this, target);

        }

        public void Init(ConstStats constStats, List<Skill> skills) {
            // TODO get team number from somewhere

            this.ConstStats = constStats;
            this.Skills = skills;
            this.DeploySkill = new Deploy();

            // TODO temporary for testing
            this.TurnStats = new TurnStats();
            this.TurnStats.SelectedSkill = skills[0];

            this.GameStats = new GameStats();
            this.GameStats.Cooldown = 0;
            this.GameStats.Deployed = false;
            this.GameStats.RemainingHealth = ConstStats.TotalHealth;

            selectionCircle = transform.Find("Selection Circle").gameObject;
            clickManager.characterSelectedEvent += SelectCharacter;
            clickManager.characterDeselectedEvent += DeselectCharacter;
        }

        public void NotifyClicked() {
            if (GameStats.Cooldown == 0) {
                clickManager.ClickedOn(this);
            }
            else {
                Debug.Log("on cooldown");
            }
        }

        public void OnAttack(Character target) {
            Vector3 dir = target.transform.position - this.transform.position;
            float step = 100000; //inf
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, step, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            animator.SetTrigger("Attack");
        }

        public void OnDodge(int animationDelay) {
            animator.SetTrigger("Dodge");
        }

        public Result OnMagicDamage(int damage, int animationDelay) {
            animator.SetTrigger("Damaged");
            // health -= damage
            // if(health <= 0) SetTrigger("Death");
            // etc...
            Result result = new Result(damage, false);
            return result;
        }

        public Result OnPhysicalDamage(int damage, int animationDelay) {
            animator.SetTrigger("Damaged");
            // health -= damage
            // if(health <= 0) SetTrigger("Death");
            // etc...
            Result result = new Result(damage, false);
            return result;
        }

        public Result OnPiercingDamage(int damage, int animationDelay) {
            animator.SetTrigger("Damaged");
            // health -= damage
            // if(health <= 0) SetTrigger("Death");
            // etc...
            Result result = new Result(damage, false);
            return result;
        }

        public void OnTurnStart() {
            this.GameStats.Cooldown--;

            this.TurnStats.ActionPoints = 1;
            this.TurnStats.RemainingMovement = ConstStats.TotalMovement;
            //this.TurnStats.SelectedSkill = GameStats.Deployed ? Skills[0] : DeploySkill;
            // TODO use the above line instead later when deployment is properly implemented
            this.TurnStats.SelectedSkill = Skills[0];
            this.TurnStats.ActiveAbilityUsed = false;
        }

        public void OnTurnEnd() {
            // empty
        }

        public bool TryMagicDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return ConstStats.DodgeChance >= rand;
        }

        public bool TryPhysicalDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return ConstStats.DodgeChance >= rand;
        }

        public void SelectCharacter(Character character) {
            if (character == this)
                selectionCircle.SetActive(true);
        }

        public void DeselectCharacter(Character character) {
            if (character == this)
                selectionCircle.SetActive(false);
        }
    }
}
