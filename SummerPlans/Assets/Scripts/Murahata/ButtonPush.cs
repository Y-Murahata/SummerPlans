using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPush : MonoBehaviour
{

    public string sceneName;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(true);
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
                AnimationSprite();

                Invoke("ChengeScene", 3.0f);

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

//    //  画像を拡大する関数
//    private void ResizeSprite()
//    {
//        //  カレンダーの画像を取得
//        GameObject calender = GameObject.Find("TITLEcalendar");

//        //  スプライトレンダーを取得
//        SpriteRenderer sr = calender.GetComponent<SpriteRenderer>();

//        bool reSizeFlag1 = false;
//        bool reSizeFlag2 = false;

//        while (true)
//        {
//            //  毎フレーム画像を真ん中にする
//            Vector3 camPos = Camera.main.transform.position;                //  カメラの座標
//            camPos.z = 0;                                                   //  奥行きはなし
//            calender.transform.position = camPos;                                    //  真ん中に移動


//            //  カレンダーのスケールが指定地(画面いっぱい)になるまで拡大
//            if (calender.transform.localScale.x <= 1.3f)
//            {
//                calender.transform.localScale.Set(calender.transform.localScale.x + 0.1f, calender.transform.localScale.y, calender.transform.localScale.z);
//            }
//            else
//            {
//                reSizeFlag1 = true;
//            }
//            if (calender.transform.localScale.y <= 1.5f)
//            {
//                calender.transform.localScale.Set(calender.transform.localScale.x, calender.transform.localScale.y + 0.1f, calender.transform.localScale.z);
//            }
//            else
//            {
//                reSizeFlag2 = true;
//            }

//            //  両方リサイズできたらループを抜ける
//            if(reSizeFlag1 == true && reSizeFlag2 ==  true)
//            {
//                break;
//            }
//        }

//    }
//}

