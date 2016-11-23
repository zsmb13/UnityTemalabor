using UnityEngine;
using System.Collections;
using System;

namespace Assets.Scripts.Model.Skills {

    public class BlinkTest : EnemySkill {

        private static readonly int cooldown = 3;
        private static readonly string name = "Blink";

        private static readonly string description =
            String.Format(
                "Moving in the shadows, this character \njumps instantly to a target \nunit in {0} cells range and \ndeal {1} piercing damage. \nFinishing an enemy resets \nthe cooldown of this character. ",
                range, damage);

        private static readonly int damage = 30;
        private static readonly float range = 5;

        public BlinkTest() : base(name, description, cooldown) {}

        protected override void OnExecute(Character source, object target) {
            Character enemy = target as Character;

            var agent = source.GetComponent<NavMeshAgent>();


            //Oda "teleportál"
            var tmpSpeed = agent.speed;
            var tmpAcc = agent.acceleration;
            var tmpStop = agent.stoppingDistance;
            agent.acceleration = 1000;
            agent.speed = 50;
            agent.stoppingDistance = 3f;


            agent.SetDestination(enemy.transform.position);

            //Lecseréli a shadert "árnyék" jellegűre
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("FX/Flare");
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Unlit/Color");
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Particles/Multiply");


            Result result = new Result(0, false);

            result = enemy.OnPiercingDamage(damage, 0);


            source.OnAttack(enemy);

            //TODO visszaállítani amikor megérkezett a célponthoz
            //agent.speed = tmpSpeed;
            //agent.acceleration = tmpAcc;
            //agent.stoppingDistnce = tmpStop;
            //agent.setDestination(null);
            //source.transform.Find("Kachujin_G_Rosales/Kachujin").GetComponent<SkinnedMeshRenderer>().material.shader = Shader.Find("Standard (Specular setup)");


            // afterattack
            // afterdefense

            source.TurnStats.ActionPoints--;
        }

        public override float GetRange(Character source) {
            return range;
        }

        public override bool IsAvailable(TurnStats stats) {
            return stats.ActionPoints > 0;
        }

        protected override bool IsValidTarget(Character source, object target) {
            // TODO check range here
            return true;
        }

    }

}