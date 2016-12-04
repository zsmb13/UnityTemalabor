using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class Blink : EnemySkill {

        private static readonly int cooldown = 3;
        private static readonly string name = "Blink";

        private static readonly int damage = 40;
        private static readonly float range = 6.0f;

        private static readonly string description =
            String.Format(
                "Moving in the shadows, this character jumps instantly to a target unit in {0} cells range and deal {1} piercing damage. Finishing an enemy resets the cooldown of this character. ",
                range, damage);

        //visszaállításhoz
        float tmpSpeed;
        float tmpAcc;
        float tmpStop;

        public Blink() : base(name, description, cooldown) {}

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
            source.OnAttack(enemy, "Active");

            source.CharacterArrivedEvent += ResetAfterPathCompletedCallback;

            Result result = enemy.OnPiercingDamage(damage, 1.0f);

            //Lecseréli a shadert "árnyék" jellegűre
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Particles/Multiply");

            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard (Specular setup)");


            source.AfterAttack(enemy, result);
            enemy.AfterDefense(source, result);

            source.TurnStats.ActiveAbilityUsed = true;
            source.TurnStats.ActionPoints--;

            //if it does kill, lower the cooldown
            if(result.Killed == true) { 
                source.GameStats.Cooldown -= cooldown;
            }
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