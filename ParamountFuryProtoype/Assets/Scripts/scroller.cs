using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scroller : MonoBehaviour {

	[SerializeField]
	string levelname;

    float timer = 45f;

	// Update is called once per frame
	void Update ()
	{
        transform.position += transform.up * Time.deltaTime * 40;
        if (Input.anyKey || timer <= 0)
        {
			SceneManager.LoadScene(levelname);
        }
        timer -= Time.deltaTime;
        print(timer);
    }
}
