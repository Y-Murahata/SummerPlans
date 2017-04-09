using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalenderManager : MonoBehaviour {

    int _day_num = 31;
    int first_num = -1;
    int second_num = -1;
    int select_num = 0;
    public static bool turn_flag = true;

    GameObject[] _1Pday_obj;
    GameObject[] _2Pday_obj;

    int[] _1Pday_state;
    int[] _2Pday_state;

    // Use this for initialization
    void Start () {
        _1Pday_obj = new GameObject[_day_num];
        _1Pday_state = new int[_day_num];

        _2Pday_obj = new GameObject[_day_num];
        _2Pday_state = new int[_day_num];

        for (int i = 0; i < _day_num; i++)
        {
            _1Pday_state[i] = 0;
            _1Pday_obj[i] = GameObject.Find("1PDays/" +(i).ToString());

            _2Pday_state[i] = 0;
            _2Pday_obj[i] = GameObject.Find("2PDays/" + (i).ToString());
        }
    }
    public void NextTurn()
    {
        first_num = -1;
        second_num = -1;
        select_num = 0;
        if (turn_flag)
        {
            turn_flag = false;
        }
        else
        {
            CollationPlan();
            turn_flag = true;
        }
    }

    void CollationPlan()
    {
        for (int i = 0; i < _day_num; i++)
        {
            if (_1Pday_state[i] + _2Pday_state[i] >= 2)
            {
                if (_1Pday_state[i] == 0 || _2Pday_state[i] == 0) continue;
                _1Pday_state[i] = 0;
                _2Pday_state[i] = 0;
            }
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
            switch (_2Pday_state[i])
            {
                case 0:
                    _2Pday_obj[i].GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    break;

                case 1:
                case 2:
                case 3:
                    _2Pday_obj[i].GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1.0f, 1.0f);
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

                if(turn_flag)
                    _1Pday_state[day_num] = select_num + 1;
                else
                    _2Pday_state[day_num] = select_num + 1;

                first_num = day_num;
            }
            else
            {
                if (IsSelected(day_num))
                {
                    if(turn_flag)
                        _1Pday_state[first_num] = 0;
                    else
                        _2Pday_state[first_num] = 0;

                    first_num = -1;
                    second_num = -1;
                    return;
                }

                second_num = day_num;

                //選択範囲が一週間以上ならば
                if (Mathf.Abs(first_num - second_num) > 7)
                {
                    if(turn_flag)
                        _1Pday_state[first_num] = 0;
                    else
                        _2Pday_state[first_num] = 0;

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
                if(turn_flag)
                    _1Pday_state[i] = select_num + 1;
                else
                    _2Pday_state[i] = select_num + 1;

            }
        }
        else
        {
            for (int i = first_num; i >= second_num; i--)
            {
                if(turn_flag)
                    _1Pday_state[i] = select_num + 1;
                else
                    _2Pday_state[i] = select_num + 1;

            }
        }
    }

    public void CancelPlan(int day_num)
    {
        if (turn_flag)
        {
            if (_1Pday_state[day_num] == 0 || first_num >= 0)
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
        }
        else
        {
            if (_2Pday_state[day_num] == 0 || first_num >= 0)
            {
                return;
            }

            int select_day_state = _2Pday_state[day_num];

            while (_2Pday_state[day_num] == select_day_state)
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

            while (_2Pday_state[day_num] == select_day_state)
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
                _2Pday_state[i] = 0;
            }

        }
        select_num--;
    }


    public bool IsSelected(int day_num)
    {
        if (turn_flag)
        {
            //選んだ日付が選択済みだったら
            if (_1Pday_state[day_num] > 0)
            {
                return true;
            }
        }
        else
        {
            //選んだ日付が選択済みだったら
            if (_2Pday_state[day_num] > 0)
            {
                return true;
            }
        }
        return false;
    }
}
