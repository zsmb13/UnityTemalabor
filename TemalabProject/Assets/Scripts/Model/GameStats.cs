using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class GameStats {
        public int Cooldown { get; set; }
        public bool Deployed { get; set; }
        public int RemainingHealth { get; set; }
        public int Team { get; set; }
    }
}
