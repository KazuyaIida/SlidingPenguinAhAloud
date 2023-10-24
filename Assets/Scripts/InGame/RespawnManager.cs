using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using penguin;

public class RespawnManager : MonoBehaviour
{
    public static int respawnCount;

    // 現在のステータスを管理するクラス
    [SerializeField] private InGameStatusManager statusManager;
    // ペンギンのGameObject
    [SerializeField] private GameObject penguin;
    // ペンギンのモデル
    [SerializeField] private GameObject penguinModel;
    // ペンギンの挙動を制御するクラス
    [SerializeField] private PenguinBehavior penguinBehavior;
    // InGameシーンのSE再生・停止クラス
    [SerializeField] private InGameAudio audio;

    // 復活できる箇所を管理するクラス
    [SerializeField] private CheckPointsManager checkPoints;

    [SerializeField] private RespawnCamera respawnCamera;

    // あと何秒で復活するかのペナルティ内容が書かれたパネル
    [SerializeField] private GameObject penaltyPanel;
    [SerializeField] private TMP_Text penaltyText;
    private readonly float penaltyTime = 3.0f;

    void Start()
    {
        respawnCount = 0;
        penaltyPanel.SetActive(false);
    }

    public IEnumerator Respawn()
    {
        if (statusManager.CurrentStatus == InGameStatus.InGameNormal || statusManager.CurrentStatus == InGameStatus.HurryUp)
        {
            respawnCount++;

            InGameStatus originalState = statusManager.CurrentStatus;
            Vector3 originalPenguinPosition = penguin.transform.position;

            // ペンギンを停止させ、操作をoffにする
            StartCoroutine(penguinBehavior.Stop(0.5f));
            penguinModel.SetActive(false);
            audio.drop.Play();
            statusManager.CurrentStatus = InGameStatus.CourseOut;

            // ペンギンをスタート地点に戻す処理    
            int penaltyCount = 0;
            penaltyPanel.SetActive(true);
            while (penaltyTime > penaltyCount)
            {
                penaltyCount++;
                penaltyText.text = "Respawning in " + (penaltyTime - penaltyCount) + " seconds.";
                yield return new WaitForSeconds(1.0f);
            }
            penaltyPanel.SetActive(false);

            respawnCamera.Teleport();
            penguin.transform.position = checkPoints.DecideRespawnPosition(originalPenguinPosition);
            penguin.transform.eulerAngles = Vector3.zero;
            penguin.GetComponent<PenguinBehavior>().enabled = true;
            penguinModel.SetActive(true);
            statusManager.CurrentStatus = originalState;
        }
    }
}
