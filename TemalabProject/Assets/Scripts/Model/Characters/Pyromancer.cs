using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Model.Skills;
using UnityEditor;

namespace Assets.Scripts.Model.Characters {

    public class Pyromancer : Character
    {
        public override void Start() {
            // always call base.Start()
            base.Start();
            
            ConstStats constStats = new ConstStats();
            // TODO use actual stats
            constStats.DodgeChance = 0;
            constStats.MagicResist = 1;
            constStats.PhysicalResist = 200;
            constStats.TotalHealth = 3;
            constStats.TotalMovement = 4;

            List<Skill> skills = new List<Skill>();
            skills.Add(new Walk());
            skills.Add(new BasicAttack());

            Init(constStats, skills);
        }

    }
    
}
