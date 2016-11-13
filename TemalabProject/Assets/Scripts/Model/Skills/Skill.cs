﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model {

    public abstract class Skill {

        public int Cooldown { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Skill(string name, string description, int cooldown) {
            Name = name;
            Description = description;
            Cooldown = cooldown;
        }

        public void Execute(Character source, object target) {
            if (target is Character) {
                if (!HasRequiredTeam(source, (Character) target)) {
                    return; // invalid target team
                }
            }

            if (!IsValidTarget(source, target)) {
                return;
            }

            OnExecute(source, target);
        }

        protected abstract bool HasRequiredTeam(Character source, Character target);

        protected abstract void OnExecute(Character source, object target);

        public abstract double GetRange(Character source);

        public abstract bool IsAvailable(TurnStats turnStats);

        protected abstract bool IsValidTarget(Character source, object target);

        public override string ToString() {
            return Name + ": " + Description;
        }

    }

}