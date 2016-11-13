using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Scripts.Model;

namespace Assets.Scripts.UI {

    public class InfoPanel : MonoBehaviour {

        public Image bgImage1;
        public Image bgImage2;
        public float fadeTime;

        public new Text name;
        public Text healthRemaining;
        public Text movementRemaining;
        public Text dodgeChance;
        public Text magicResist;
        public Text physicalResist;

        public Text basicAttackName;
        public Text basicAttackDescription;
        public Text activeSkillName;
        public Text activeSkillDescription;

        public List<Text> textsToFade;

        void Start() {
            bgImage1.CrossFadeAlpha(0f, 0, true);
            bgImage2.CrossFadeAlpha(0f, 0, true);

            foreach (var text in textsToFade) {
                text.CrossFadeAlpha(0f, 0, true);
            }
        }

        void Update() {
            // Fade();
        }

        public void ShowInfo(Character character) {
            ConstStats constStats = character.ConstStats;
            TurnStats turnStats = character.TurnStats;
            GameStats gameStats = character.GameStats;

            name.text = constStats.Name;
            healthRemaining.text = gameStats.RemainingHealth.ToString();
            movementRemaining.text = turnStats.RemainingMovement.ToString("0.##");
            dodgeChance.text = constStats.DodgeChance.ToString();
            magicResist.text = constStats.MagicResist.ToString();
            physicalResist.text = constStats.PhysicalResist.ToString();

            Skill basicAttack = character.Skills[1];
            Skill activeSkill = character.Skills[2];

            basicAttackName.text = basicAttack.Name;
            basicAttackDescription.text = basicAttack.Description;
            activeSkillName.text = activeSkill.Name;
            activeSkillDescription.text = activeSkill.Description;

            gameObject.SetActive(true);
            FadeIn();
        }

        public void Hide() {
            FadeOut();
        }

        private void FadeIn() {
            bgImage1.CrossFadeAlpha(1f, fadeTime, false);
            bgImage2.CrossFadeAlpha(1f, fadeTime, false);

            foreach (var text in textsToFade) {
                text.CrossFadeAlpha(1f, fadeTime, false);
            }
        }

        private void FadeOut() {
            bgImage1.CrossFadeAlpha(0f, fadeTime, false);
            bgImage2.CrossFadeAlpha(0f, fadeTime, false);

            foreach (var text in textsToFade) {
                text.CrossFadeAlpha(0f, fadeTime, false);
            }
        }

    }

}