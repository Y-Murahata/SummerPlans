using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour {

    private int _1P_count = 0;
    private int _2P_count = 0;

    public GameObject _1P_text;
    public GameObject _2P_text;
    public GameObject MVP_sign;

    // Use this for initialization
    void Start () {

        MVP_sign.SetActive(false);

        //  プレイヤーたちのスコアを保存
        for (int i = 0; i < 31; i++)
        {
            if (CalenderManager._1Pday_state[i] >= 1)
            {
                _1P_count++;
            }
            if (CalenderManager._2Pday_state[i] >= 1)
            {
                _2P_count++;
            }
        }

        //  テキストコンポーネントの取得
        _1P_text = GameObject.Find("_1P_Text");
        _2P_text = GameObject.Find("_2P_Text");


    }
	
	// Update is called once per frame
	void Update () {
        //  テキストをスコアに書き換える
        _1P_text.GetComponent<Text>().text = "1P　スコア　　" + (_1P_count).ToString();
        _2P_text.GetComponent<Text>().text = "2P　スコア　　" + (_2P_count).ToString();

        //  スコアの多いプレイヤーを検出
        if (_1P_count > _2P_count)
        {
            MVP_sign.transform.position = new Vector3(-4.851f, 2.47f);
            //  王冠マークを表示
            MVP_sign.SetActive(true);
        }
        else if(_1P_count < _2P_count)
        {
            MVP_sign.transform.position = new Vector3(-4.851f, -0.09f);
            //  王冠マークを表示
            MVP_sign.SetActive(true);
        }
        else if (_1P_count == _2P_count)
        {

        }

    }
}
