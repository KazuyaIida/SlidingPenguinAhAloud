using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentManager : MonoBehaviour
{
    public static readonly int totalTrialNum = 3;
    public static int currentTrialCount;

    [SerializeField]
    private Button retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.interactable = currentTrialCount + 1 < totalTrialNum;
    }
}
