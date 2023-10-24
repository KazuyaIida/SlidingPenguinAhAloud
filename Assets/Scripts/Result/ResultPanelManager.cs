using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultPanelManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text trialText;
    [SerializeField]
    private TMP_Text gameResultText;
    [SerializeField]
    private TMP_Text goalTimeText;
    [SerializeField]
    private TMP_Text continueText;
    [SerializeField]
    private TMP_Text fishText;

    public void Initialize(int currentTrial)
    {
        Color textColor = new Color(1.0f, 1.0f, 1.0f, 0.50f);

        trialText.text = "Trial " + (currentTrial + 1).ToString();

        gameResultText.text = "Not Played";
        gameResultText.color = textColor;

        goalTimeText.text = "00:00";
        goalTimeText.color = textColor;

        continueText.text = "0";
        continueText.color = textColor;

        fishText.text = "0";
        fishText.color = textColor;
    }

    public void DrawResult(Result result)
    {
        trialText.text = "Trial " + (result.trialCount + 1).ToString();
        gameResultText.text = CovertClearStatus(result.clearStatus);
        goalTimeText.text = FormatTime((int)result.clearTime);
        continueText.text = result.continueCount.ToString();
        fishText.text = result.fishCount.ToString();
    }

    private string CovertClearStatus(bool isSucceeded)
    {
        if (isSucceeded)
        {
            gameResultText.color = new Color(0.0f, 0.80f, 1.0f);
            return "Game Clear";
        }
        else
        {
            gameResultText.color = new Color(1.0f, 0.0f, 0.0f);
            return "Time Over";
        }
    }

    private string FormatTime(int seconds)
    {
        // 符号を取得し、絶対値に変換
        string sign = seconds < 0 ? "-" : "";
        seconds = Mathf.Abs(seconds);

        // 分と秒を計算
        int minutes = seconds / 60;
        seconds = seconds % 60;

        // 分:秒の形にフォーマット
        return string.Format("{0}{1:D2}:{2:D2}", sign, minutes, seconds);
    }
}
