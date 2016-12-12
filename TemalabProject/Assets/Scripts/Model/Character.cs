using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model {

    public abstract class Character : MonoBehaviour {

        public event CharacterEvent CharacterArrivedEvent;
        public event CharacterEvent CharacterKilled;

        public ClickManager clickManager;

        public ConstStats ConstStats { get; set; }
        public GameStats GameStats { get; set; }
        public TurnStats TurnStats { get; set; }

        public Skill DeploySkill { get; set; }
        public List<Skill> Skills { get; set; }

        private Animator animator;
        private GameObject selectionCircle;
        private HealthBar healthBar;
        private CooldownBar cooldownBar;

        public virtual void Start() {
            animator = gameObject.transform.GetComponent<Animator>();
        }

        public virtual void Update() {
            updateInfoBars();
        }

        public virtual void AfterAttack(Character target, Result result) {
            // empty
        }

        public virtual void AfterDefense(Character source, Result result) {
            // empty
        }

        public void Animate(string triggerName) {
            animator.SetTrigger(triggerName);
        }

        public void Deselect() {
            selectionCircle.SetActive(false);
        }

        public List<Skill> GetSkills() {
            List<Skill> skills = new List<Skill>();

            if (GameStats.Deployed) {
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
            this.ConstStats = constStats;
            this.Skills = skills;
            this.DeploySkill = new Deploy();

            this.TurnStats = new TurnStats();
            this.TurnStats.SelectedSkill = skills[0];

            this.GameStats = new GameStats();
            this.GameStats.Cooldown = 0;
            this.GameStats.Deployed = false;
            this.GameStats.RemainingHealth = ConstStats.TotalHealth;

            if (transform.Find("Team 1 UI") != null) {
                selectionCircle = transform.Find("Team 1 UI/Selection Circle").gameObject;
                healthBar = transform.Find("Team 1 UI/Health Bar").GetComponent<HealthBar>();
                cooldownBar = transform.Find("Team 1 UI/Cooldown Bar").GetComponent<CooldownBar>();
            }
            else if (transform.Find("Team 2 UI") != null) {
                selectionCircle = transform.Find("Team 2 UI/Selection Circle").gameObject;
                healthBar = transform.Find("Team 2 UI/Health Bar").GetComponent<HealthBar>();
                cooldownBar = transform.Find("Team 2 UI/Cooldown Bar").GetComponent<CooldownBar>();
            }
            else {
                throw new UnityException("Nincs UI gameobject!!");
            }
        }

        public void NotifyClicked() {
            clickManager.ClickedOn(this);
        }

        public void OnWalk() {
            StartCoroutine(AnimateWalk());
        }

        private IEnumerator AnimateWalk() {
            animator.SetBool("Moving", true);

            yield return new WaitUntil(PathCompleted);

            animator.SetBool("Moving", false);
            if (CharacterArrivedEvent != null) {
                CharacterArrivedEvent(this);
            }
        }

        private bool PathCompleted() {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            if (!agent.pathPending) {
                if (agent.remainingDistance <= agent.stoppingDistance) {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                        return true;
                    }
                }
            }
            return false;
        }

        public void OnAttack(Character target, string trigger, float rotationOffset = 0.0f) {
            Vector3 dir = target.transform.position - this.transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, 100000, 0.0F);
            newDir = Quaternion.Euler(0, rotationOffset, 0)*newDir;
            transform.rotation = Quaternion.LookRotation(newDir);
            animator.SetTrigger(trigger);
        }

        public void OnDodge(float animationDelay) {
            StartCoroutine(AnimateDodge(animationDelay));
        }

        protected abstract float GetDodgeDelay();

        private IEnumerator AnimateDodge(float animationDelay) {
            float attackDelay = animationDelay;
            float dodgeDelay = GetDodgeDelay();

            yield return new WaitForSecondsRealtime(attackDelay - dodgeDelay);

            animator.SetTrigger("Dodge");
        }

        public Result OnMagicDamage(int damage, float animationDelay) {
            int reducedDamage = Math.Max(damage - ConstStats.MagicResist, 0);
            return OnDamage(reducedDamage, Result.MagicDamage, animationDelay);
        }

        public Result OnPhysicalDamage(int damage, float animationDelay) {
            int reducedDamage = Math.Max(damage - ConstStats.PhysicalResist, 0);
            return OnDamage(reducedDamage, Result.PhysicalDamage, animationDelay);
        }

        public Result OnPiercingDamage(int damage, float animationDelay) {
            return OnDamage(damage, Result.PiercingDamage, animationDelay);
        }

        private Result OnDamage(int reducedDamage, int damageType, float animationDelay) {
            Result result = new Result(reducedDamage, damageType, false);

            GameStats.RemainingHealth -= reducedDamage;

            if (GameStats.RemainingHealth == 0) {
                StartCoroutine(AnimateDeath(animationDelay));
                result.Killed = true;
                if (CharacterKilled != null) {
                    CharacterKilled(this);
                }
            }
            else {
                StartCoroutine(AnimateDamage(animationDelay));
            }

            return result;
        }

        protected abstract float GetDamagedDelay();

        private IEnumerator AnimateDamage(float animationDelay) {
            float attackDelay = animationDelay;
            float reactDelay = GetDamagedDelay();

            yield return new WaitForSecondsRealtime(attackDelay - reactDelay);

            animator.SetTrigger("Damaged");
        }

        private IEnumerator WaitForAnimation(Animation animation) {
            do yield return null; while (animation.isPlaying);
        }

        protected abstract float GetDeathDelay();

        private IEnumerator AnimateDeath(float animationDelay) {
            float attackDelay = animationDelay;
            float deathDelay = GetDeathDelay();

            float startDelay = attackDelay - deathDelay;

            yield return new WaitForSecondsRealtime(startDelay);

            animator.SetTrigger("Death");

            float disappearDelay = startDelay + 2.3f;

            yield return new WaitForSecondsRealtime(disappearDelay);

            gameObject.SetActive(false);
        }

        public virtual void OnTurnStart() {
            GameStats.Cooldown--;

            TurnStats.ActionPoints = 1;
            TurnStats.RemainingMovement = ConstStats.TotalMovement;
            TurnStats.SelectedSkill = GameStats.Deployed ? Skills[0] : DeploySkill;
            TurnStats.ActiveAbilityUsed = false;
        }

        public virtual void OnTurnEnd() {
            // empty
        }

        public void Select() {
            selectionCircle.SetActive(true);
        }

        public bool TryMagicDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return ConstStats.DodgeChance >= rand;
        }

        public virtual bool TryPhysicalDodge() {
            float rand = UnityEngine.Random.Range(0, 100);
            return ConstStats.DodgeChance >= rand;
        }

        public void showInfoBars() {
            healthBar.gameObject.SetActive(true);
            cooldownBar.gameObject.SetActive(true);
        }

        public void updateInfoBars() {
            healthBar.SetFillAmount(((float)GameStats.RemainingHealth) / ConstStats.TotalHealth);
            cooldownBar.SetFillAmount(((float)GameStats.Cooldown) / 6.0f);
        }

    }

}