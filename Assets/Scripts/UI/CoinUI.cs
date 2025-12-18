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
        public TextMeshProUGUI CurrentCoinText { get; private set; }
        [field: SerializeField]
        public TextMeshProUGUI MaxCoinText { get; private set; }
        
        [field: SerializeField]
        public Transform PlayerTransform { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
            var maxCoin = PlayerPrefs.GetInt("MaxCoinAmount");
            MaxCoinText.text = maxCoin.ToString();
        }
        
        void FixedUpdate()
        {
            Vector3 direction = transform.position - PlayerTransform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public void Connect(Bag bag)
        {
            Debug.Log("Connect");
            CurrentCoinText.text = bag.CurrentCoin.ToString();
            OnCoinGain?.Invoke();
            if (bag.CurrentCoin > bag.MaxCoin)
            {
                OnNewMaxScore?.Invoke();
            }
        }

    }
}