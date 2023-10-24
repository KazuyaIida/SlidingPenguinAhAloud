using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrialCounter : MonoBehaviour
{
    private TMP_Text trialCountText;

    // Start is called before the first frame update
    void Start()
    {
        trialCountText = GetComponent<TMP_Text>();
        trialCountText.text = "Trial " + (ExperimentManager.currentTrialCount + 1).ToString();
    }
}
