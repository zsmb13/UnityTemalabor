using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CooldownBar : MonoBehaviour {

    private Image cooldownBarImage;

	// Use this for initialization
	void Start () {
        cooldownBarImage = transform.Find("Cooldown Bar Canvas/Cooldown Bar Image").GetComponent<Image>();
    }

    public void SetFillAmount(float currentPerMaxCooldown) {
        if (cooldownBarImage != null)
            cooldownBarImage.fillAmount = currentPerMaxCooldown;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
