using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Pyromancer : Character
    {
        public void Awake() {
            
            ConstStats constStats = new ConstStats();
            // TODO use actual stats
            constStats.Name = "Kyra";
            constStats.CharacterType = "Pyromancer";
            constStats.DodgeChance = 50;
            constStats.MagicResist = 1;
            constStats.PhysicalResist = 200;
            constStats.TotalHealth = 3;
            constStats.TotalMovement = 40;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack_Pyromancer());

            Init(constStats, skills);
        }

    }
    
}
