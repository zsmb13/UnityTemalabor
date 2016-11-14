using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model.Skills {

    public abstract class MiscSkill : Skill {

        protected MiscSkill(string name, string description, int cooldown) : base(name, description, cooldown) {}

        protected sealed override bool HasRequiredTeam(Character source, object target) {
            return true;
        }

    }

}