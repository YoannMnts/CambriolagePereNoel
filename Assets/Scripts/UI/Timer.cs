using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [field: SerializeField]
        public TextMeshProUGUI TimerText { get; private set; }
        
        [field: SerializeField]
        public Image FillImage { get; private set; }
        
        [field: SerializeField, Range(0, 5)]
        public int Time { get; private set; }
        
        private int currentTime;

        private void Awake()
        {
            currentTime = Time * 60;
            CooldownTimer();
        }

        private async Awaitable CooldownTimer()
        {
            
            if (currentTime > 0)
            {
                currentTime -= 1;
                TimerText.text = currentTime.ToString();
                FillImage.fillAmount = (float)currentTime / (Time * 60);
                await Awaitable.WaitForSecondsAsync(1);
                CooldownTimer();
            }
            Application.Quit();
        }
    }
}
