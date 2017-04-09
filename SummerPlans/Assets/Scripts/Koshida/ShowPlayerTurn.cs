using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowPlayerTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CalenderManager.turn_flag)
        {
            this.GetComponent<Text>().text = "1P";
            this.GetComponent<Text>().color = Color.red;
            //this.GetComponent<Outline>().effectColor
        }
        else
        {
            this.GetComponent<Text>().text = "2P";
            this.GetComponent<Text>().color = Color.blue;
        }
    }
}
