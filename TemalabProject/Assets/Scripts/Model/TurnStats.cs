using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class TurnStats {

        public int ActionPoints { get; set; }
        public bool ActiveAbilityUsed { get; set; }

        private float remainingMovement;
        public float RemainingMovement {
            get { return remainingMovement; }
            set { remainingMovement = value < 0 ? 0 : value; }
        }

        public Skill SelectedSkill { get; set; }

    }
}
