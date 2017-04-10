using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalenderManager : MonoBehaviour {

    int _day_num = 31;
    int first_num = -1;
    int second_num = -1;

    public static int round_count = 0;
    public static int select_num = 0;
    public static bool turn_flag = true;

    GameObject[] _1Pday_obj;
    GameObject[] _2Pday_obj;

    public  static int[] _1Pday_state;
    public static int[] _2Pday_state;

    public GameObject calender;

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

        this.GetComponent<AudioSource>().Play();

        calender.GetComponent<SlideCalender>().SlideIn();

        if (turn_flag)
        {
            turn_flag = false;
        }
        else
        {
            CollationPlan();
            turn_flag = true;

            round_count++;
            if(round_count >= 3)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }

        CountDown.count = CountDown.round_time[round_count];

        first_num = -1;
        second_num = -1;
        select_num = 0;
    }

    void CollationPlan()
    {
        for (int i = 0; i < _day_num; i++)
        {
            //1Pの選んだ予定が二日の予定の場合
            if(IsTwoDaysPlan(i,true))
            {
                //2Pの選んだ先が二日の予定じゃなかった場合
                if(!IsTwoDaysPlan(i,false))
                {
                    CancelPlan(i);
                }
            }

            //1Pの選んだ予定が二日の予定の場合
            if (IsTwoDaysPlan(i, false))
            {
                //2Pの選んだ先が二日の予定じゃなかった場合
                if (!IsTwoDaysPlan(i, true))
                {
                    turn_flag = true;
                    CancelPlan(i);
                    turn_flag = false;
                }
            }

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
                if (Mathf.Abs(first_num - second_num) > 6)
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

    //予定が二日のみかどうか
    bool IsTwoDaysPlan(int day_num,bool player)
    {
        int two_days_ago = day_num - 2;
        int in_two_days = day_num + 2;

        if (two_days_ago < 0)
            two_days_ago = 0;
        if (in_two_days >= _day_num)
            in_two_days = _day_num - 1;

        //1Pの予定の検索
        if (player)
        {
            //二日前が違う予定の場合
            if (_1Pday_state[two_days_ago] != _1Pday_state[day_num])
            {
                //二日後が違う予定の場合
                if (_1Pday_state[in_two_days] != _1Pday_state[day_num])
                {
                    //一日前が違う予定の場合
                    if (_1Pday_state[two_days_ago + 1] != _1Pday_state[day_num])
                    {
                        return true;
                    }
                    else
                    {
                        //一日後が違う予定の場合
                        if (_1Pday_state[in_two_days - 1] != _1Pday_state[day_num])
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {

            }
        }
        else
        {
            //二日前が違う予定の場合
            if (_2Pday_state[two_days_ago] != _2Pday_state[day_num])
            {
                //二日後が違う予定の場合
                if (_2Pday_state[in_two_days] != _2Pday_state[day_num])
                {
                    //一日前が違う予定の場合
                    if (_2Pday_state[two_days_ago + 1] != _2Pday_state[day_num])
                    {
                        return true;
                    }
                    else
                    {
                        //一日後が違う予定の場合
                        if (_2Pday_state[in_two_days - 1] != _2Pday_state[day_num])
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
