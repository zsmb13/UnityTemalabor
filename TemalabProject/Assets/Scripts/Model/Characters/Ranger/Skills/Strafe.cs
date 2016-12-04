using System;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Model.Skills {

    public class Strafe : EnemySkill {

        private static readonly int cooldown = 3;
        private static readonly string name = "Strafe";
        private static readonly int damage = 90;
        private static readonly float range = float.MaxValue;
        private static readonly string description = String.Format("Deal {0} physical damage to a single target unit. ", damage);
        private static readonly float shootAngle = 15;
        private GameObject projectile;
        private Transform projectileSpawn;


        private static readonly float animationDelay = 0.8f;

        public Strafe(GameObject projectile, Transform projectileSpawn) : base(name, description, cooldown) {
            this.projectile = projectile;
            this.projectileSpawn = projectileSpawn;
        }

        //TODO: implement passive skills
        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            float distance = Vector3.Distance(enemy.transform.position, source.transform.position);
            //additional animation delay based on projectile path
            float animationAndDistanceDelay = animationDelay + distance / shootAngle;

            Result result = new Result();
            result = enemy.OnPiercingDamage(damage, animationAndDistanceDelay);

            shootProjectile(source.transform, enemy.transform);
            source.OnAttack(enemy, "Active", 90);

            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActionPoints--;
        }

        private void shootProjectile(Transform source, Transform target) {
            GameObject arrow = GameObject.Instantiate(projectile, projectileSpawn.position, Quaternion.identity, source) as GameObject;
            arrow.GetComponent<Projectile>().Launch(target.position, shootAngle, animationDelay);
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

    }

}