using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class CJC_HudManagerP1 : MonoBehaviour {

	[SerializeField]
	GameObject jerryparent;

	[SerializeField]
	float healthfill;
	[SerializeField]
	private Image healthbar;

	[SerializeField]
	float staminahfill;
	[SerializeField]
	private Image staminabar;

	[SerializeField]
	float furyfill;
	[SerializeField]
	private Image furybar;

	[SerializeField]
	Image heart1;
	[SerializeField]
	Image heart2;
	[SerializeField]
	Image heart3;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Updatefury (furyfill);
		UpdateStamin (staminahfill);
		UpdateHealth (healthfill);
		updatelives ();
	}

	void UpdateHealth(float value)
	{
		GameObject jerrbear = jerryparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();
		if (!jerry.hasdied) {
			healthfill = jerry.health / jerry.healthmax * 1;
			healthbar.fillAmount = healthfill;
		}
	}

	void updatelives()
	{
		GameObject jerrbear = jerryparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();
		if (jerry.playerlives >= 3)
		{
			heart1.enabled = true;
			heart2.enabled = true;
			heart3.enabled = true;
		}
		else if (jerry.playerlives == 2)
		{
			heart1.enabled = true;
			heart2.enabled = true;
			heart3.enabled = false;
		}
		else if (jerry.playerlives == 1)
		{
			heart1.enabled = true;
			heart2.enabled = false;
			heart3.enabled = false;
		}
		else if (jerry.playerlives == 0)
		{
			heart1.enabled = false;
			heart2.enabled = false;
			heart3.enabled = false;
		}

	}

	void Updatefury(float value)
	{
		GameObject jerrbear = jerryparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();


		if (!jerry.hasdied)
		{
			furyfill = jerry.furybar / jerry.furybarmax * 1;
			furybar.fillAmount = furyfill;
		}
	}

	void UpdateStamin(float value)
	{
		GameObject jerrbear = jerryparent;
		CJC_HinezController jerry = jerrbear.GetComponent<CJC_HinezController> ();
		if (!jerry.hasdied) {
			staminahfill = jerry.staminabar / jerry.staminabarmax * 1;
			staminabar.fillAmount = staminahfill;
		}
	}
}
