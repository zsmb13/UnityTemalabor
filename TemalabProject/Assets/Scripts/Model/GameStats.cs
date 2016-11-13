using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {
    public class GameStats {
        private int cooldown;
        public int Cooldown {
            get { return cooldown; }
            set {
                if (value >= 0) {
                    cooldown = value;
                }
            }
        }

        public bool Deployed { get; set; }
        public int RemainingHealth { get; set; }
        public int Team { get; set; }
    }
}
