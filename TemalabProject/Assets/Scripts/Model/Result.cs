using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class Result {
        public int DamageDone { get; private set; }
        public int DamageType { get; private set; }
        public bool Killed { get; set; }

        public static readonly int None = -1;
        public static readonly int PiercingDamage = 0;
        public static readonly int MagicDamage = 1;
        public static readonly int PhysicalDamage = 2;

        public Result() {
            DamageDone = 0;
            Killed = false;
            DamageType = None;
        }

        public Result(int damageDone, int damageType, bool killed) {
            DamageDone = damageDone;
            DamageType = damageType;
            Killed = killed;
        }
    }
}
