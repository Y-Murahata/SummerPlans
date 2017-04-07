using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour {

    public string sceneName;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //ボタンが押されたらシーンを切り替える処理
    public void ButtonPushed()
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);

            //  押されたら消える
            gameObject.SetActive(false);

            Debug.Log("シーンを"+sceneName+"に切り替える");
        }
        else
        {
            Debug.Log("シーンが選ばれていません");
        }
 


    }
}
