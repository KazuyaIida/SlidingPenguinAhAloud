using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result
{
    public int trialCount;
    public bool clearStatus;
    public float clearTime;
    public int continueCount;
    public int fishCount;

    public Result(int _trialCount, bool _clearStatus, float _clearTime, int _continueCount, int _fishCount)
    {
        trialCount = _trialCount;
        clearStatus = _clearStatus;
        clearTime = _clearTime;
        continueCount = _continueCount;
        fishCount = _fishCount;
    }
}

public class ResultsManager : MonoBehaviour
{
    public static Result[] results = new Result[ExperimentManager.totalTrialNum];

    [SerializeField]
    private GameObject trialResultPanelPrefab;
    private GameObject[] trialResultPanels;

    [SerializeField]
    private GameObject mainCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        trialResultPanels = new GameObject[ExperimentManager.totalTrialNum];
        for (int i = 0; i < ExperimentManager.totalTrialNum; i++)
        {
            trialResultPanels[i] = Instantiate(trialResultPanelPrefab, mainCanvas.transform);
            trialResultPanels[i].transform.position = new Vector3((i - 1.0f) * 260.0f, 40.0f, 0);

            if (i <= ExperimentManager.currentTrialCount) { trialResultPanels[i].GetComponent<ResultPanelManager>().DrawResult(results[i]); }
            else { trialResultPanels[i].GetComponent<ResultPanelManager>().Initialize(i); }
        }
    }
}
