using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderManager : MonoBehaviour {

    int _day_num = 31;
    int first_num = -1;
    int second_num = -1;
    static int select_num = 0;

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
        for (int i = 0; i < _day_num; i++)
        {
            switch (_1Pday_state[i])
            {
                case 0:
                    _1Pday_obj[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    break;

                case 1:
                case 2:
                case 3:
                    _1Pday_obj[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                    break;
            }
        }
    }

    //日付の選択
    public void SelectDay(int day_num)
    {
        if (select_num < 3)
        {

            if (first_num < 0)
            {
                if (IsSelected(day_num))
                {
                    return;
                }

                _1Pday_state[day_num] = select_num + 1;

                first_num = day_num;
            }
            else
            {
                if (IsSelected(day_num))
                {
                    _1Pday_state[first_num] = 0;
                    first_num = -1;
                    second_num = -1;
                    return;
                }

                second_num = day_num;

                //選択範囲が一週間以上ならば
                if (Mathf.Abs(first_num - second_num) > 7)
                {
                    _1Pday_state[first_num] = 0;
                    first_num = -1;
                    second_num = -1;
                    return;
                }

                EnterPlan(first_num, second_num);
                first_num = -1;
                second_num = -1;
                select_num++;
            }
        }
    }



    //予定の確定
    void EnterPlan(int first_num,int second_num)
    {

        if (first_num < second_num)
        {
            for (int i = first_num; i<= second_num;i++)
            {
                _1Pday_state[i] = select_num + 1;
            }
        }
        else
        {
            for (int i = first_num; i >= second_num; i--)
            {
                _1Pday_state[i] = select_num + 1;
            }
        }
    }

    public void CancelPlan(int day_num)
    {
        if (_1Pday_state[day_num] == 0)
        {
            return;
        }

        int select_day_state = _1Pday_state[day_num];

        while (_1Pday_state[day_num] == select_day_state)
        {
            day_num++;
            if (day_num >= _day_num)
            {
                day_num = _day_num;
                break;
            }
        }

        day_num--;
        int top_day = day_num;

        while (_1Pday_state[day_num] == select_day_state)
        {
            day_num--;
            if (day_num < 0)
            {
                day_num = 0;
                break;
            }
        }

        day_num++;
        int bottom_day = day_num - 1;

        for (int i = bottom_day; i <= top_day; i++)
        {
            _1Pday_state[i] = 0;
        }

        select_num--;
    }


    public bool IsSelected(int day_num)
    {
        //選んだ日付が選択済みだったら
        if(_1Pday_state[day_num] > 0)
        {
            return true;
        }

        return false;
    }
}
