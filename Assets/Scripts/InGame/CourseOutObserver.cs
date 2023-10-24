using System.Collections;
using System.Collections.Generic;
using penguin;
using UnityEngine;

public class CourseOutObserver : MonoBehaviour
{
    // ゲーム終了時の処理をするクラス
    [SerializeField] private GameOverManager gameOverManager;
    // リスポーンする処理をするクラス
    [SerializeField] private RespawnManager respawnManager;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // スタート地点から復活
            StartCoroutine(respawnManager.Respawn());
        }
    }

}
