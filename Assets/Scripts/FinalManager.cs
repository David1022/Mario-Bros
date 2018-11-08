using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FinalManager : MonoBehaviour {

    static OutputData outputData;
    public Text timeText;
    public Text scoreText;
    public Text coinText;

    void Start () {
        ReadWinner();
    }

    public void ReadWinner()
    {
        AssetDatabase.ImportAsset(SaveLoad.OUTPUT_PATH);

        TextAsset data = Resources.Load<TextAsset>(SaveLoad.FINAL_INPUT_PATH);
        outputData = JsonUtility.FromJson<OutputData>(data.ToString());

        string time = "";
        string score = "";
        string coin = "";

        if ((outputData.time != "") && (outputData.score != "") && (outputData.coin != null)) 
        {
            time = "Time : " + outputData.time;
            score = outputData.score;
            coin = outputData.coin;
        }
        timeText.text = time;
        scoreText.text = score;
        coinText.text = coin;
    }

    void Update () {
		    
	}
}
