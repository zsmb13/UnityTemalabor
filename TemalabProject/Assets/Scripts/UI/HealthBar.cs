using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    //private Canvas canvas;
    private Image healthBarImage;

	// Use this for initialization
	void Start () {
        healthBarImage = transform.Find("Health Bar Canvas/Health Bar Image").GetComponent<Image>();
	}
	
	public void SetFillAmount(float currentPerMaxHealth) {
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentPerMaxHealth;
    }

    // Update is called once per frame
	void Update () {
	
	}
}
