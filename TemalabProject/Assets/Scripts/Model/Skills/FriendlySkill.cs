using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {

    public abstract class FriendlySkill : Skill {

        protected sealed override bool HasRequiredTeam(Character source, Character target) {
            return source.GameStats.Team == target.GameStats.Team;
        }
        

    }

}
