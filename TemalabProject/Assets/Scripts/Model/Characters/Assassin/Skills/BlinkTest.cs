using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class BlinkTest : EnemySkill {

        private static readonly int cooldown = 3;
        private static readonly string name = "Blink";

        private static readonly int damage = 70;
        private static readonly float range = 8.0f;

        private static readonly string description =
            String.Format(
                "Moving in the shadows, this character \njumps instantly to a target \nunit in {0} cells range and \ndeal {1} piercing damage. \nFinishing an enemy resets \nthe cooldown of this character. ",
                range, damage);

        //TMP teszt
        float tmpSpeed;
        float tmpAcc;
        float tmpStop;

        public BlinkTest() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            var agent = source.GetComponent<NavMeshAgent>();

            //Oda "teleportál"
            tmpSpeed = agent.speed;
            tmpAcc = agent.acceleration;
            tmpStop = agent.stoppingDistance;
            agent.acceleration = 1000;
            agent.speed = 50;
            agent.stoppingDistance = 1.5f;

            //a két karakter közötti vektor irányában egységnyivel arrébb áll meg, hogy ne legyen a két karakter "egymásban"
            agent.SetDestination(enemy.transform.position - Vector3.Normalize(enemy.transform.position - source.transform.position));
            source.OnWalk();
            source.OnAttack(enemy, "Active");

            source.CharacterArrivedEvent += ResetAfterPathCompletedCallback;


            Result result = enemy.OnPiercingDamage(damage, 1.0f);


            //Lecseréli a shadert "árnyék" jellegűre
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Particles/Multiply");

            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard (Specular setup)");


            // afterattack
            // afterdefense

            source.TurnStats.ActiveAbilityUsed = true;
            source.TurnStats.ActionPoints--;
            
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

        private void ResetAfterPathCompletedCallback(Character source) {
            var agent = source.GetComponent<NavMeshAgent>();
            agent.ResetPath();
            agent.speed = tmpSpeed;
            agent.acceleration = tmpAcc;
            agent.stoppingDistance = tmpStop;
            source.CharacterArrivedEvent -= ResetAfterPathCompletedCallback;
        }

    }

}