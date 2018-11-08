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

        if ((outputData.time != "") && (outputData.score != "")) 
        {
            time = "Time : " + outputData.time;
            score = outputData.score;
        }
        timeText.text = time;
        scoreText.text = score;
    }

    void Update () {
		    
	}
}
