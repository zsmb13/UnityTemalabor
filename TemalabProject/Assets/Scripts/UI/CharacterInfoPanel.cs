using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Model;
using System;

namespace Assets.Scripts.UI
{
    public class CharacterInfoPanel : MonoBehaviour
    {
        public Text info;
        public Image bgImage;
        Boolean displayInfo;
        public float fadeTime;

        void Start()
        {
            bgImage = GetComponent<Image>();
        }

        void Update()
        {
            Fade();
        }

        public void ShowConstInfo(String constStats)
        {
            gameObject.SetActive(true);
            info.text = constStats;
            displayInfo = true;
        }

        public void Hide()
        {
            displayInfo = false;
        }

        void Fade()
        {
            if (displayInfo)
            {
                // Fade in
                bgImage.CrossFadeAlpha(1f, fadeTime, false);
                info.color = Color.Lerp(info.color, Color.black, 1 / fadeTime * Time.deltaTime);
            } else
            {
                // Fade out
                bgImage.CrossFadeAlpha(0f, fadeTime, false);
                info.color = Color.Lerp(info.color, Color.clear, 1 / fadeTime * Time.deltaTime);
            }
        }
    }
}