using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;

namespace Assets.Scripts.Model.Characters
{

    public class Vampire : Character
    {

        public void Awake()
        {
            ConstStats constStats = new ConstStats();

            constStats.Name = "Vincente";
            constStats.CharacterType = "Vampire";
            constStats.DodgeChance = 0;
            constStats.MagicResist = 5;
            constStats.PhysicalResist = 5;
            constStats.TotalHealth = 200;
            constStats.TotalMovement = 8.0f;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Vampire());
            skills.Add(new SoulSiphon());

            Init(constStats, skills);
        }

        protected override float GetDeathDelay()
        {
            return 0.2f;
        }

        protected override float GetDodgeDelay()
        {
            Debug.Log("Vampire dodge delay is missing");
            return 0;
        }

        protected override float GetDamagedDelay()
        {
            return 0.2f;
        }
    }
}