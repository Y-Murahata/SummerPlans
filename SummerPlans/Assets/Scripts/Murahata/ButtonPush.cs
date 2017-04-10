using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{

    public string sceneName;
    private GameObject titleSprite;
    public float stopTime;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
        titleSprite = GameObject.Find("title");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ボタンが押されたらシーンを切り替える処理
    public void ButtonPushed()
    {
        //シーンが読み込める時
        if (sceneName != null)
        {
            //  タイトルシーンの時
            if(SceneManager.GetActiveScene().name == "Title")
            {
                //  タイトル画像の非表示
                titleSprite.SetActive(false);
                //  アニメーションの実行
                AnimationSprite();
                //  シーン切り替えを遅延実行
                Invoke("ChengeScene", stopTime);
            }
            if (SceneManager.GetActiveScene().name == "Result")
            {
                //  シーンを切り替える
                SceneManager.LoadScene(sceneName);
            }

           
            //  ボタンは押されたら消える
            gameObject.SetActive(false);



            Debug.Log("シーンを" + sceneName + "に切り替える");
        }
        //  シーンが読み込めない時
        else
        {
            Debug.Log("シーンが選ばれていません");
        }
    }

    //  タイトルシーンでボタンを押したときの処理
    private void AnimationSprite()
    {
        //  テーブルとカレンダーのアニメーターを取得する
        GameObject tabeleObject = GameObject.Find("Table");
        GameObject calenderObject = GameObject.Find("TITLEcalendar");

        Animator tableAnimator = tabeleObject.GetComponent<Animator>();
        Animator calenderAnimator = calenderObject.GetComponent<Animator>();

        tableAnimator.SetBool("ButtonFlag", true);
        calenderAnimator.SetBool("ButtonFlag", true);
    }


    //  シーンを切り替える関数
    private void ChengeScene()
    {
        //  シーンを切り替える
        SceneManager.LoadScene(sceneName);
    }


}


