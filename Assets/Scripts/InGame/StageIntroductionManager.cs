using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class StageIntroductionManager : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ステージ紹介用カメラの挙動を管理するクラス
        [SerializeField] private StageIntroductionCamera stageIntroductionCamera;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;

        // ゲーム開始前カウントダウン処理をするクラス
        [SerializeField] private CountDown countDown;

        private void Start()
        {
            stageIntroductionCamera.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // 演出をスキップ
            if(statusManager.CurrentStatus == InGameStatus.StageIntroduction) { Finish(); }
        }

        // ステージ紹介が終了した際に呼び、UIやモードを切り替える関数。
        private void Finish()
        {
            stageIntroductionCamera.Reset();
            stageIntroductionCamera.gameObject.SetActive(false);
            audio.stageIntoro.Pause();
            StartCoroutine(countDown.ChangeMode());
        }

    }

}
