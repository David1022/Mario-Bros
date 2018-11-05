using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static int time;

    public Text timeLabel;

    // Use this for initialization
    void Start () {
        time = 0;

        timeLabel.text = "Time : " + time + " s";

        InvokeRepeating("Chrono", 1f, 1f);
    }

    void Chrono() {
        time++;
        timeLabel.text = "Time : " + time + " s";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
