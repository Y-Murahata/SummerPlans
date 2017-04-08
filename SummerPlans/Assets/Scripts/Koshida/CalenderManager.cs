using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderManager : MonoBehaviour {

    int _day_num = 31;

    GameObject[] _1Pday_obj;

    int[] _1Pday_state;

    // Use this for initialization
    void Start () {
        _1Pday_obj = new GameObject[_day_num];
        _1Pday_state = new int[_day_num];

        for (int i = 0; i < _day_num; i++)
        {
            _1Pday_state[i] = 0;
            _1Pday_obj[i] = GameObject.Find((i).ToString());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SelectDay(int first_num,int second_num)
    {
        //選択範囲が一週間以上ならば
        if (Mathf.Abs(first_num - second_num) > 7)
        {
            _1Pday_state[first_num] = 0;

            ChangeColor(first_num);            
            return;
        }

        if (first_num < second_num)
        {
            for (int i = first_num; i<= second_num;i++)
            {
                _1Pday_state[i] = 1;
                ChangeColor(i);
            }
        }
        else
        {
            for (int i = first_num; i >= second_num; i--)
            {
                _1Pday_state[i] = 1;
                ChangeColor(i);
            }
        }
    }

    void ChangeColor(int day_num)
    {
        switch(_1Pday_state[day_num])
        {
            case 0:
                _1Pday_obj[day_num].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;

            case 1:
                _1Pday_obj[day_num].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                break;
        }
    }

    public bool IsSelected(int day_num)
    {
        //選んだ日付が選択済みだったら
        if(_1Pday_state[day_num] > 0)
        {
            Debug.Log(_1Pday_state[day_num]);
            return true;
        }

        return false;
    }
}
