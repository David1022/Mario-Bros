﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class SaveLoad
{

    public static string OUTPUT_PATH = "Assets/Resources/OutputData.txt";
    public static string FINAL_INPUT_PATH = "OutputData";

    public static void Save(string time, string score, string coin) {
        OutputData outputData = new OutputData();
        outputData.time = time;
        outputData.score = score;
        outputData.coin = coin;

        string json = JsonUtility.ToJson(outputData);

        if (json != null) {
            if (System.IO.File.Exists(OUTPUT_PATH))
            {
                System.IO.File.Delete(OUTPUT_PATH);
            }
            string path = OUTPUT_PATH;
            StreamWriter writer = new StreamWriter(path, true);
            writer.Write(json);
            writer.Close();
        }
    }
}
