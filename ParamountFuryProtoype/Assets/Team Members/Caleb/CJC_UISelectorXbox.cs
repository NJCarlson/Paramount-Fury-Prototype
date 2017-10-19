using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CJC_UISelectorXbox : MonoBehaviour 
{
	public GameObject[]selectableUI;
	static public int SelectedUI = 0;

	public string[] selectableUIScenes;
	static public int SelectedUIScenes = 0;

	bool hasbeenmoved = false;

	public float LastSize = 1;
	public float selectedSize = 1.5f;

	[SerializeField]
	float holdTimer = 0;



	private bool SelectedLevel = false;

	bool pressed = false;


	// Use this for initialization
	void Start () 
	{
		Screen.fullScreen = true;
		SelectedUI = 0;
		SelectedUIScenes = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (CJC_CheckforController.controlleractive)
		{
			SelectedUIString ();
			ManageSelectedUISize ();
			testInPut ();
			ManageButtonAction ();
			changeUIimage ();
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

	void testInPut()
	{
		

		if (holdTimer >= 0.3f) 
		{
			hasbeenmoved = false;
			holdTimer = 0;
		}

		if (Input.GetAxisRaw ("Vertical") > 0.1f | Input.GetAxisRaw ("Vertical") < 0) 
		{
			holdTimer += Time.unscaledDeltaTime;
		}
		else if (Input.GetAxisRaw ("Vertical") == 0) 
		{
			holdTimer = 0;
		}


		if (Input.GetAxisRaw ("Vertical") > 0.1f && hasbeenmoved == false && !SelectedLevel) 
		{// Debug.Log ("up");
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
		else if (Input.GetAxisRaw ("Vertical") <0 && hasbeenmoved == false && !SelectedLevel) 
		{
			//Debug.Log ("down");
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
		}
		else if (Input.GetAxisRaw ("Vertical") == 0) 
		{
			//Debug.Log ("nothing pressed");
			hasbeenmoved = false;
			holdTimer = 0;
		}





		/*if (Input.GetKeyDown(KeyCode.W) && hasbeenmoved == false) 
		{
			//Debug.Log ("up");
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
			//Debug.Log ("down");
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

	void changeUIimage(){
		

	}

	void ManageSelectedUISize()
	{
		selectableUI [SelectedUI].transform.localScale = new Vector3 (selectedSize, selectedSize, selectedSize);
	}

	void ReadyUp()
	{
		if (SelectedUIScenes == selectableUIScenes.Length-1)
		{
			Debug.Log ("exit game");
			pressed = false;
			Application.Quit ();

		} 
		else if (SelectedUIScenes == 2)
		{
			//Debug.Log ("exit game");
			pressed = false;
			//Application.Quit ();
			SceneManager.LoadScene(selectableUIScenes[2]);

		} 
		else if (SelectedUIScenes == 1)
		{
			//Debug.Log ("exit game");
			pressed = false;
			//Application.Quit ();
			SceneManager.LoadScene(selectableUIScenes[1]);

		} 
		else if (SelectedUIScenes == 0)
		{
			//Debug.Log ("exit game");
			pressed = false;
			//Application.Quit ();
			SceneManager.LoadScene(selectableUIScenes[0]);

		} 


	}

	void ManageButtonAction()
	{
		if (Input.GetButtonDown ("360_AButton") | Input.GetKeyDown(KeyCode.Return)) 
		{
			pressed = true;


			//SelectedLevel = true;
			Invoke ("ReadyUp", 1f);

		}
	}
}
