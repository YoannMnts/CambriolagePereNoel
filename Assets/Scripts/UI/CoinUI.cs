using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinUI : MonoBehaviour
    {
        public static CoinUI Instance { get; private set; }
        
        public event Action OnCoinGain;
        public event Action OnNewMaxScore;
        [field: SerializeField]
        public CanvasGroup CanvasGroup { get; private set; }
        [field: SerializeField]
        public TextMeshPro CurrentCoinText { get; private set; }
        [field: SerializeField]
        public TextMeshPro MaxCoinText { get; private set; }
        public int CurrentCoin { get; private set; }
        public int MaxCoin { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            MaxCoin = PlayerPrefs.GetInt("MaxCoinAmount", 0);
            MaxCoinText.text = MaxCoin.ToString();
        }

        public void AddCoin(int coinAmount)
        {
            CurrentCoin = coinAmount;
            CurrentCoinText.text = coinAmount.ToString();
            OnCoinGain?.Invoke();
            if (CurrentCoin > MaxCoin)
            {
                OnNewMaxScore?.Invoke();
            }
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("MaxCoinAmount", CurrentCoin);
        }
    }
}