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
        //string time = "Time : " + outputData.time;
        //string score = "Score : " + outputData.score;
        string time = "Time : " + 100;
        string score = "Score : " + 20;

        timeText.text = time;
        scoreText.text = score;
    }

    void Update () {
		
	}
}
