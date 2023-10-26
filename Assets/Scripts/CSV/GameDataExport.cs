using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

public enum ExportData
{
    ScoreData,
    TrailData
}

public class CSV
{
    public int trialCount;
    public bool isSucceeded;
    public int fishNumber;
    public int continueNumber;
    public float clearTime;
    public float distance;
    public float sensitivity;
    public float limitedTime;

    public CSV(int _trialCount, bool _isSucceeded, int _fishNumber, int _continueNumber, float _clearTime, float _distance, float _sensitivity, float _limitedTime)
    {
        trialCount = _trialCount;
        isSucceeded = _isSucceeded;
        fishNumber = _fishNumber;
        continueNumber = _continueNumber;
        clearTime = _clearTime;
        distance = _distance;
        sensitivity = _sensitivity;
        limitedTime = _limitedTime;
    }

    public string[] ConvertData2List()
    {
        string[] returnList = {
            CovertClearStatus(isSucceeded),
            fishNumber.ToString(), 
            continueNumber.ToString(), 
            clearTime.ToString(), 
            distance.ToString(), 
            sensitivity.ToString(), 
            limitedTime.ToString()
        };
        return returnList;
    }

    private string CovertClearStatus(bool isSucceeded)
    {
        if (isSucceeded) { return "Game Clear"; }
        else { return "Time Over"; }
    }
}

public class GameDataExport : MonoBehaviour
{
    public static CSV[] csv = new CSV[ExperimentManager.totalTrialNum];

    // System.IO
    private static StreamWriter scoreSW;

    public static void SaveGameData()
    {
        DateTime currentTime = DateTime.Now;
        string year = currentTime.Year.ToString();
        string month = currentTime.Month.ToString();
        string day = currentTime.Day.ToString();
        string hour = currentTime.Hour.ToString();
        string minute = currentTime.Minute.ToString();
        string second = currentTime.Second.ToString();

        // SaveDataフォルダが存在しない場合は、新しく作る
        if (!Directory.Exists(Application.dataPath + "/ScoreData")) { Directory.CreateDirectory(Application.dataPath + "/ScoreData"); }
        scoreSW = new StreamWriter(@Application.dataPath + "/ScoreData/" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "_result.csv",
            false, Encoding.GetEncoding("UTF-8"));

        // ラベルを書き込む
        string[] labels = { "Success", "FishNumber", "ContinueNumber", "ClearTime", "Distance", "Sensitivity", "LimitedTime" };

        // 文字列配列のすべての要素を「,」で連結する
        string label = string.Join(",", labels);

        // 「,」で連結した文字列をcsvファイルへ書き込む
        scoreSW.WriteLine(label);

        // 各試行で得られたデータを順番に書き込む
        for (int i = 0; i < ExperimentManager.totalTrialNum; i++)
        {
            if (i <= ExperimentManager.currentTrialCount)
            {
                string[] score = csv[i].ConvertData2List();
                string scoreData = string.Join(",", score);
                scoreSW.WriteLine(scoreData);
            }
            else
            {
                string[] score = {
                    "Not Played",
                    "0",
                    "0",
                    "0",
                    "0",
                    "Not Set",
                    "Not Set"
                };
                string scoreData = string.Join(",", score);
                scoreSW.WriteLine(scoreData);
            }
        }

        scoreSW.Close();
    }
}
