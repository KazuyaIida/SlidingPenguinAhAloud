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
            // �������擾���A��Βl�ɕϊ�
            string sign = remainingTime < 0 ? "-" : "";
            remainingTime = Mathf.Abs(remainingTime);

            // ���ƕb���v�Z
            int minutes = remainingTime / 60;
            remainingTime = remainingTime % 60;

            // ��:�b�̌`�Ƀt�H�[�}�b�g
            return string.Format("{0}{1:D2}:{2:D2}", sign, minutes, remainingTime);
        }
    }
}
