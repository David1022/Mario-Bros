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

    private void saveWinnerAndOpenNextScreen(Player winner)
    {
        string winnerName = "";
        if (winner.Equals(Player.P1))
        {
            winnerName = PLAYER1;
        }
        else
        {
            winnerName = PLAYER2;
        }

        SaveLoad.Save(winnerName);
        OpenFinalScreen.LaunchPlayScreen();
    }

}
