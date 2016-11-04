using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class ConstStats {
        public string Name { get; set; }
        public string CharacterType { get; set; }
        public int DodgeChance { get; set; }
        public int MagicResist { get; set; }
        public int PhysicalResist { get; set; }
        public int TotalHealth { get; set; }
        public double TotalMovement { get; set; }

        public override String ToString()
        {
            String info = Name.ToString()+" the " + CharacterType.ToString() + Environment.NewLine +
                          "Dodge chance: " + DodgeChance.ToString() + Environment.NewLine +
                          "Magic resist: " + MagicResist.ToString() + Environment.NewLine +
                          "Physical resist: " + PhysicalResist.ToString() + Environment.NewLine +
                          "Total health: " + TotalHealth.ToString() + Environment.NewLine +
                          "Total movement: " + TotalMovement.ToString();

            return info;
        }
    }
}
