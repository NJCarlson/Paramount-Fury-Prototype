using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_mouseRotation : MonoBehaviour {


	void Update () 
	{
		IfControllerPluggedIn ();
		IfControllerNotPluggedIn ();
	}

	void IfControllerPluggedIn()
	{
		if (CJC_CheckforController.controlleractive) {
			
			//Get the Screen positions of the object
			//Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

			//Get the Screen position of the mouse
			//Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);

			//Get the angle between the points
			//float angle = AngleBetweenTwoPoints (positionOnScreen, mouseOnScreen);

			//Ta Daaa
			//transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, Input.GetAxis("360_RightStick")));
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
