using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Title")
            Destroy(this.gameObject);

        if (SceneManager.GetActiveScene().name == "Result")
            Destroy(this.GetComponent("SlideCalender"));
    }
}
