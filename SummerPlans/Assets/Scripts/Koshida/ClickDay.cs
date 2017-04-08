using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDay : MonoBehaviour {

    int _first_num,_second_num;
    GameObject cm_obj;

	// Use this for initialization
	void Start () {
        _first_num = -1;
        _second_num = -1;
        cm_obj = GameObject.Find("CalendarManager");
	}
	
	// Update is called once per frame
	void Update () {
        //左クリックされたとき
		if(Input.GetMouseButtonDown(0))
        {
            //マウスポインタの位置をワールド座標に変換
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

            //オブジェクトに当たった時
            if (hit)
            {
                CalenderManager cm = cm_obj.GetComponent<CalenderManager>();

                //一回目の選択がまだだったら
                if (_first_num < 0)
                {
                    _first_num = int.Parse(hit.collider.name);
                    if(cm.IsSelected(_first_num))
                    {
                        _first_num = -1;
                        return;
                    }
                    GameObject obj = hit.collider.gameObject;
                    obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
                }
                else
                {
                    _second_num = int.Parse(hit.collider.name);
                    
                    cm.SelectDay(_first_num, _second_num);
                    _first_num = -1;
                    _second_num = -1;
                }
            }
        }
    }
}
