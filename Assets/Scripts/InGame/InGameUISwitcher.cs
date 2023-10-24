using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class InGameUISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject remainingTimeUI;

        [SerializeField] private GameObject ItemUI;

        [SerializeField] private GameObject timeUPUI;

        [SerializeField] private GameObject trialCountUI;

        // Start is called before the first frame update
        void Start()
        {
            remainingTimeUI.SetActive(false);
            ItemUI.SetActive(false);
            timeUPUI.SetActive(false);
            trialCountUI.SetActive(false);
        }

        public void ActivateInGameUI()
        {
            remainingTimeUI.SetActive(true);
            ItemUI.SetActive(true);
            trialCountUI.SetActive(true);
        }
        
        public void UnActivateInGameUI()
        {
            remainingTimeUI.SetActive(false);
            ItemUI.SetActive(false);
            trialCountUI.SetActive(false);
        }

        public void ActivateTimeUpUI()
        {
            timeUPUI.SetActive(true);
        }
    }

}

