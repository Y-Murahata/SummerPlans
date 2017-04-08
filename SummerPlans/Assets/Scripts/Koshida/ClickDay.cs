﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDay : MonoBehaviour {

    GameObject cm_obj;

	// Use this for initialization
	void Start () {
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

                cm.SelectDay(int.Parse(hit.collider.name));
            }
        }

        if(Input.GetMouseButtonDown(1))
        {
            //マウスポインタの位置をワールド座標に変換
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

            //オブジェクトに当たった時
            if (hit)
            {
                CalenderManager cm = cm_obj.GetComponent<CalenderManager>();

                cm.CancelPlan(int.Parse(hit.collider.name));
            }
        }
    }
}
