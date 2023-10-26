using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
    public class SceneSwitcher : MonoBehaviour
    {
        // Startシーンに遷移するボタン
        [SerializeField] private Button homeButton;
        
        // InGameシーンに遷移し再プレイするボタン
        [SerializeField] private Button retryButton;

        // InGameシーンに遷移し次の試行を実行するボタン
        [SerializeField] private Button nextButton;

        // SE再生・停止クラス
        [SerializeField] private ResultSceneAudio audio;
        
        // Start is called before the first frame update
        void Start()
        {
            homeButton.onClick.AddListener(() => StartCoroutine("LoadStartScene"));
            retryButton.onClick.AddListener(() => StartCoroutine("LoadInGameScene"));
            nextButton.onClick.AddListener(() => StartCoroutine("LoadNextInGameScene"));
        }
        
        
        private IEnumerator LoadStartScene()
        {
            audio.TransitionClick.Play();
            yield return new WaitForSeconds(1.0f);

            // Resultデータをすべて破棄する
            ResultsManager.results = new Result[ExperimentManager.totalTrialNum];
            // CSVデータをすべて破棄する
            GameDataExport.csv = new CSV[ExperimentManager.totalTrialNum];

            // Trialのカウントをリセットする
            ExperimentManager.currentTrialCount = 0;

            SceneManager.LoadScene ("Start");
        }
    
        private IEnumerator LoadInGameScene()
        {
            audio.TransitionClick.Play();
            yield return new WaitForSeconds(1.0f);

            SceneManager.LoadScene ("InGame");
        }

        private IEnumerator LoadNextInGameScene()
        {
            audio.TransitionClick.Play();
            yield return new WaitForSeconds(1.0f);

            // Trialのカウントを更新する
            ExperimentManager.currentTrialCount++;

            SceneManager.LoadScene("InGame");
        }
    }

}
