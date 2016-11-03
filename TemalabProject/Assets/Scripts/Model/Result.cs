using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class Result {
        public int DamageDone { get; set; }
        public bool Killed { get; set; }

        public Result(int damageDone, bool killed) {
            DamageDone = damageDone;
            Killed = killed;
        }
    }
}
