using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    public static float[] round_time = new float[3];

    public static float count;

    GameObject cm_obj;

    CalenderManager cm;

	// Use this for initialization
	void Start () {
        cm_obj = GameObject.Find("CalendarManager");
        round_time[0] = 60.0f;
        round_time[1] = 40.0f;
        round_time[2] = 20.0f;

        count = round_time[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        count -= Time.deltaTime;

        if(count < 0)
        {
            cm.NextTurn();
        }
    }
}
