using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public abstract class Skill {

        public int cooldown;
        public string name;
        public string description;

        public abstract void Execute(Character source, object target);

        public abstract double GetRange(Character source);

        public abstract bool IsAvailable(TurnStats turnStats);

        protected abstract bool IsValidTarget(object target);
        
        public override string ToString() {
            return name + ": " + description;
        }

    }

}
