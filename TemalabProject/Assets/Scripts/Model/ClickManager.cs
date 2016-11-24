using UnityEngine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Model {

    public delegate void CharacterEvent(Character character);

    public class ClickManager : MonoBehaviour {

        public TurnManager turnManager;
        public PlayerManager playerManager;

        public Character SelectedCharacter {
            get { return selected; }
            private set { selected = value; }
        }

        private Character selected = null;


        public event CharacterEvent characterSelectedEvent;
        public event CharacterEvent characterDeselectedEvent;
        public event CharacterEvent characterSkillExecutedEvent;

        public void ClickedOn(object clickTarget) {
            if (clickTarget is Character) {
                ClickedOnCharacter((Character) clickTarget);
            }
            else {
                ClickedOnTerrain(clickTarget);
            }
        }

        private void ClickedOnTerrain(object clickTarget) {
            if (selected != null) {
                selected.GiveTarget(clickTarget);
                if (characterSkillExecutedEvent != null) {
                    characterSkillExecutedEvent(selected);
                }
            }
        }

        private void ClickedOnCharacter(Character target) {
            if (selected == null) {
                if (target.GameStats.Cooldown > 0) {
                    return;
                }

                int team = target.GameStats.Team;
                if (team != turnManager.CurrentTeam) {
                    return;
                }
                if (!target.GameStats.Deployed && !playerManager.GetPlayerByTeamID(team).CanDeploy()) {
                    return;
                }

                SelectedCharacter = target;
                target.Select();
                //Selected event meghívása
                if (characterSelectedEvent != null) {
                    characterSelectedEvent(selected);
                }
            }
            else {
                if (!target.GameStats.Deployed) {
                    return;
                }
                selected.GiveTarget(target);
                if (characterSkillExecutedEvent != null) {
                    characterSkillExecutedEvent(selected);
                }
            }
        }

        public
            void RemoveSelected() {
            if (
                characterDeselectedEvent != null) {
                characterDeselectedEvent(selected);
            }
            if (
                SelectedCharacter != null) {
                SelectedCharacter.Deselect
                    ();
            }
            SelectedCharacter = null;
        }

    }

}