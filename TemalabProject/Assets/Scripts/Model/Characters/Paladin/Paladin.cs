using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Characters
{

    public class Paladin : Character
    {
        //passive
        private static readonly int physicalDodge = 25;

        public void Awake()
        {
            ConstStats constStats = new ConstStats();

            constStats.Name = "Rhoden";
            constStats.CharacterType = "Paladin";
            constStats.DodgeChance = 0;
            constStats.MagicResist = 5;
            constStats.PhysicalResist = 15;
            constStats.TotalHealth = 250;
            constStats.TotalMovement = 8.0f;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Paladin());
            skills.Add(new Lockdown());

            Init(constStats, skills);
        }

        protected override float GetDeathDelay()
        {
            return 0.2f;
        }

        protected override float GetDodgeDelay()
        {
            Debug.Log("Paladin dodge delay is missing");
            return 0;
        }

        protected override float GetDamagedDelay()
        {
            return 0.2f;
        }

        public override bool TryPhysicalDodge()
        {
            float rand = UnityEngine.Random.Range(0, 100);

            return physicalDodge >= rand;
        }
    }
}