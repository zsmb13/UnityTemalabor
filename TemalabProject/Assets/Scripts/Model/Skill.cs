using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public abstract class Skill {

        int cooldown;
        string name;
        string description;

        public abstract void Execute(Character source, Unit target);

        public abstract double GetRange();

        public abstract bool IsAvailable(TurnStats stats);

        protected abstract bool IsValidTarget(Unit target);

    }

}
