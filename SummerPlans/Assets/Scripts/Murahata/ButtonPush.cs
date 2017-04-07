using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //ボタンが押されたらシーンを切り替える処理
    public void ButtonPushed()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
