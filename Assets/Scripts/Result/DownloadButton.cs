using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
    public class DownloadButton : MonoBehaviour
    {
        // データをダウンロードするボタン
        [SerializeField] private Button dataDownloadButton;
        
        // SE再生・停止クラス
        [SerializeField] private ResultSceneAudio audio;
     
         void Start()
         {
             dataDownloadButton.onClick.AddListener(Clicked);
         }

         private void Clicked()
         {
            GameDataExport.SaveGameData();
            audio.NormalClick.Play();
         }
    }
}
