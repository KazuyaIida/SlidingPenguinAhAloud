using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
    public class RemainingTimeText : MonoBehaviour
    {
        [SerializeField] private Text remainingTimeText;

        public void Set(int remainingTime)
        {
            remainingTimeText.text = Adjust(remainingTime);
        }

        public void TurnRed()
        {
            remainingTimeText.color = Color.red;
        }
    
        private string Adjust(int remainingTime)
        {
            // 符号を取得し、絶対値に変換
            string sign = remainingTime < 0 ? "-" : "";
            remainingTime = Mathf.Abs(remainingTime);

            // 分と秒を計算
            int minutes = remainingTime / 60;
            remainingTime = remainingTime % 60;

            // 分:秒の形にフォーマット
            return string.Format("{0}{1:D2}:{2:D2}", sign, minutes, remainingTime);
        }
    }
}
