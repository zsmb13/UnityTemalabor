using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class TurnStats {

        public int ActionPoints { get; set; }
        public bool ActiveAbilityUsed { get; set; }
        public double RemainingMovement { get; set; }
        public Skill SelectedSkill { get; set; }

    }
}
