using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_mouseRotation : MonoBehaviour {


	public string horizontalaxis = "360_RightStickH";
	public string verticalaxis = "360_RightStickV";

	[SerializeField]
	float testangle = 30;

	void Update () 
	{
		IfControllerPluggedIn ();
		IfControllerNotPluggedIn ();
	}

	void IfControllerPluggedIn()
	{
		if (CJC_CheckforController.controlleractive)
		{

			float rx = Input.GetAxis ("360_RightStickH");
			float rY = Input.GetAxis ("360_RightStickV");

			float angle = Mathf.Atan2 (rx, rY);
			transform.rotation = Quaternion.EulerAngles (0, 0, angle+testangle);


			//Vector3 shootDirection = Vector3.right * Input.GetAxis (horizontalaxis) + Vector3.forward * Input.GetAxis (verticalaxis);
			
			//transform.rotation = Quaternion.LookRotation (shootDirection, Vector3.up);

			//transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, -Input.GetAxis("360_RightStick")* Time.deltaTime* 1000));
		}

	}

	void IfControllerNotPluggedIn()
	{
		if (!CJC_CheckforController.controlleractive) {
			Cursor.visible = true;
			//Get the Screen positions of the object
			Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

			//Get the Screen position of the mouse
			Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);

			//Get the angle between the points
			float angle = AngleBetweenTwoPoints (positionOnScreen, mouseOnScreen);

			//Ta Daaa
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
		}

		if (CJC_CheckforController.controlleractive)
		{
			Cursor.visible = false;
		}
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
			return Mathf.Atan2 (a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

}
