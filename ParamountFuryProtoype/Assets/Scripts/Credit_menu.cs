using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit_menu : MonoBehaviour {

    float timer = 18f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (Input.anyKey || timer <= 0) { 
            SceneManager.LoadScene("MainMenu");
        }
        timer -= Time.deltaTime;
        print(timer);
    }
}
