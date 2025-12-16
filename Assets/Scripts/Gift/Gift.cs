using UI;
using UnityEngine;

namespace Gift
{
    public class Gift : MonoBehaviour, IInterctable
    {
        public GiftData GiftData { get; private set; }
        
        public void Interact()
        {
            CoinUI.Instance.AddCoin(GiftData.CoinGain);
            Destroy(gameObject);
        }

        public void SetData(GiftData giftData)
        {
            GiftData = giftData;
        }
    }
}