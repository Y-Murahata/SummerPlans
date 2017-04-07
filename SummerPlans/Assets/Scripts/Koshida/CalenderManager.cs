using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderManager : MonoBehaviour {

    int _day_num = 31;

    GameObject[] _1Pdays;
    // Use this for initialization
    void Start () {
        _1Pdays = new GameObject[_day_num];

        for (int i = 0; i < _day_num; i++)
            _1Pdays[i] = GameObject.Find((i).ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeColor(int first_num,int second_num)
    {
        if(first_num < second_num)
        {
            for (int i = first_num; i<= second_num;i++)
            {
                _1Pdays[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                Debug.Log(first_num);
            }
        }
        else
        {
            for (int i = first_num; i >= second_num; i--)
            {
                _1Pdays[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                Debug.Log(first_num);
            }
        }
    }
}
