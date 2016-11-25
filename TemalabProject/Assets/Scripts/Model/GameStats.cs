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

        private int remainingHealth;

        public int RemainingHealth {
            get {
                return remainingHealth;
                ;
            }
            set {
                if (value < 0) {
                    value = 0;
                }
                remainingHealth = value;
            }
        }

        public int Team { get; set; }

    }

}