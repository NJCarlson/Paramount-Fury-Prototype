using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CJC_InGameXboxUISelector : MonoBehaviour {
	public GameObject[]selectableUI;
	public int SelectedUI = -1;

	public string[] selectableUIScenes;
	public int SelectedUIScenes = -1;

	[SerializeField]
	bool hasbeenmoved = false;

	public float LastSize = .66f;
	public float selectedSize = .8f;

	[SerializeField]
	float holdTimer = 0;

	static public bool hastoshowcontrols = false;
	bool pressed = false;


	bool readiedUP;
	[SerializeField]
	GameObject OBJTurnOn;
	[SerializeField]
	GameObject OBJTurnOff;

// Use this for initialization
void Start () 
{
	SelectedUI = 0;
	SelectedUIScenes = 0;
}

// Update is called once per frame
void Update () 
{
		if (CJC_CheckforController.controlleractive) {
			SelectedUIString ();
			ManageSelectedUISize ();
			testInPut ();
			ManageButtonAction ();
			changeUIimage ();
			ReadyUp ();
			if (!pressed) {
				//selectableUI [SelectedUI].gameObject.GetComponent<Image> ().sprite = selected;
			}
		}
}

void SelectedUIString()
{
	SelectedUIScenes = SelectedUI;

	if (SelectedUIScenes == selectableUIScenes.Length-1) 
	{
		Debug.Log ("Selected UI String is exit game");
	}
	else
		Debug.Log ("Selected UI String is" + selectableUIScenes.GetValue(SelectedUIScenes));
	//Debug.Log ("Selected UI piece is" + SelectedUI);
}
	void changeUIimage()
	{
		//if(!pressed)
			//selectableUI [SelectedUI].gameObject.GetComponent<Image> ().sprite = selected;

	}

void testInPut()
{
		if (!pressed) {
			//selectableUI [SelectedUI].gameObject.GetComponent<Image> ().sprite = nothing;
		}

		if (holdTimer >= .4f) 
		{
			hasbeenmoved = false;
			holdTimer = 0;
		}

		if (Input.GetAxisRaw ("Vertical") > 0.01f | Input.GetAxisRaw ("Vertical") < 0) 
		{
			holdTimer += Time.unscaledDeltaTime;
		}

		if (Input.GetAxisRaw ("Vertical") > 0.01f && hasbeenmoved == false) 
	{ 
			hasbeenmoved = true;

		if (SelectedUI >= 0)
		{
			selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);
		}
			SelectedUI--;
			//GetComponent<AudioSource> ().PlayOneShot (buttonmoved);

		if (SelectedUI < 0) 
		{
				SelectedUI = selectableUI.Length-1 ;
				//GetComponent<AudioSource> ().PlayOneShot (buttonmoved);
		}
		selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);

	}
		else if (Input.GetAxisRaw ("Vertical") <0 && hasbeenmoved == false) 
	{
	hasbeenmoved = true;

		if (SelectedUI >= 0)
		{
			selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);
		}
			SelectedUI++;
			//GetComponent<AudioSource> ().PlayOneShot (buttonmoved);

		if (SelectedUI >= selectableUI.Length) 
		{
				SelectedUI = 0;
				//GetComponent<AudioSource> ().PlayOneShot (buttonmoved);
		}
		selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);
	}
		else if (Input.GetAxisRaw ("Vertical") == 0) 
	{
		//Debug.Log ("nothing pressed");
			holdTimer = 0;
		hasbeenmoved = false;
	}




	/*if (Input.GetKey(KeyCode.S)| Input.GetKey(KeyCode.W)) 
	{
		holdTimer += Time.unscaledDeltaTime;
	}


	if (Input.GetKeyDown(KeyCode.W) && hasbeenmoved == false) 
	{
			hasbeenmoved = true;

		if (SelectedUI >= 0)
		{
			selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);

		}
		SelectedUI--;

		if (SelectedUI < 0) 
		{
			SelectedUI = selectableUI.Length-1 ;
		}
		selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);

	}
	else if (Input.GetKeyDown(KeyCode.S) && hasbeenmoved == false)
	{
			hasbeenmoved = true;

		if (SelectedUI >= 0)
		{
			selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);

		}
		SelectedUI++;

		if (SelectedUI >= selectableUI.Length) 
		{
			SelectedUI = 0;
		}
		selectableUI [SelectedUI].transform.localScale = new Vector3 (LastSize, LastSize, LastSize);
	}*/
}

void ManageSelectedUISize()
{
	selectableUI [SelectedUI].transform.localScale = new Vector3 (selectedSize, selectedSize, selectedSize);
}


	void ReadyUp()
	{
		if (readiedUP) 
		{
			

			if (SelectedUIScenes == selectableUIScenes.Length - 1) {
				//GetComponent<AudioSource> ().PlayOneShot (buhbye);
				Debug.Log ("exit game");
				Application.Quit ();
			}
		/*
		else if (SelectedUI == 0 && core.ControllerToldMeToTurnYouOn == false)
		{
			core.ControllerToldMeToTurnYouOn = true;
			Debug.Log ("showing Controls");
			pressed = false;
		}

		else if (SelectedUI == 0 && core.ControllerToldMeToTurnYouOn == true)
		{
			core.ControllerToldMeToTurnYouOn = false;
			Debug.Log ("closing Controls");
			pressed = false;
		}
		*/
		else if (SelectedUI == 1) {
			}

		}
	}

void ManageButtonAction()
{
	if (Input.GetButtonDown ("360_AButton") | Input.GetKeyDown(KeyCode.Return)) 
	{


			pressed = true;
			//selectableUI [SelectedUI].gameObject.GetComponent<Image> ().sprite = pressdown;


			if (SelectedUI == 0)
			{
				OBJTurnOff.SetActive (false);
				OBJTurnOn.SetActive (true);
				//GetComponent<AudioSource> ().PlayOneShot (buttonpressed);
				//Invoke ("controls", .1f);
				//core1.paused = false;
				hastoshowcontrols = true;

			} 
			else if (SelectedUI == 1)
			{
				//GetComponent<AudioSource> ().PlayOneShot (buttonpressed);
				UnityEngine.SceneManagement.SceneManager.LoadScene(selectableUIScenes[1]);
				//core1.paused = false;
				//hastoshowcontrols = true;

			} 
			else if (SelectedUI == 2)
			{
				//GetComponent<AudioSource> ().PlayOneShot (buttonpressed);
				UnityEngine.SceneManagement.SceneManager.LoadScene(selectableUIScenes[2]);
				//core1.paused = false;
				//hastoshowcontrols = true;

			} 
			else
			{

				//GetComponent<AudioSource> ().PlayOneShot (buttonpressed);
				//ReadyUp();
				//core1.paused = false;
				Invoke("callreaadyUP",.03f);
			}
	}
}

	void callreaadyUP()
	{
		readiedUP = true;
	}
}
