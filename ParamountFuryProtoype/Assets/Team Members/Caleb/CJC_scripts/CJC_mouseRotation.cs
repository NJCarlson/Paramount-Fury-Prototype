using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJC_mouseRotation : MonoBehaviour {


	public string horizontalaxis = "360_RightStickH";
	public string verticalaxis = "360_RightStickV";

	[SerializeField]
	float testangle = 89.55f;

	void Update ()
	{
		GameObject pitbull = GameObject.FindWithTag("GameController");
		CJC_MissionControl mr305 = pitbull.GetComponent<CJC_MissionControl> ();

		if (!mr305.missioncompleted) {

			if (CJC_CheckforController.controlleractive) {
				IfControllerPluggedIn ();
			} else if (!CJC_CheckforController.controlleractive) {
				IfControllerNotPluggedIn ();
			}
		}
	}

	void IfControllerPluggedIn()
	{
		Cursor.visible = false;
			float rx = Input.GetAxis ("360_RightStickH");
			float rY = Input.GetAxis ("360_RightStickV");



			float angle = Mathf.Atan2 (rx, rY);

			if (Input.GetAxis("360_RightStickH") >.1f | Input.GetAxis("360_RightStickH") <0f | Input.GetAxis("360_RightStickV") >.1f | Input.GetAxis("360_RightStickV") <0f)
			transform.rotation = Quaternion.EulerAngles (0, 0, angle+testangle);


			//Vector3 shootDirection = Vector3.right * Input.GetAxis (horizontalaxis) + Vector3.forward * Input.GetAxis (verticalaxis);
			
			//transform.rotation = Quaternion.LookRotation (shootDirection, Vector3.up);

			//transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, -Input.GetAxis("360_RightStick")* Time.deltaTime* 1000));


	}

	void IfControllerNotPluggedIn()
	{
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

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
			return Mathf.Atan2 (a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

}
