using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour {

    private int _1P_count = 0;
    private int _2P_count = 0;

    public GameObject _1P_text;
    public GameObject _2P_text;

    // Use this for initialization
    void Start () {

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

    }
}
