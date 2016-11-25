using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {

    public abstract class EnemySkill : Skill {

        protected EnemySkill(string name, string description, int cooldown) : base(name, description, cooldown) {}

        protected sealed override bool HasRequiredTeam(Character source, object target) {
            var character = target as Character;
            if (character != null) {
                return source.GameStats.Team != character.GameStats.Team;
            }
            return false;
        }

        protected override bool IsValidTarget(Character source, object target) {
            return true;
        }

    }

}