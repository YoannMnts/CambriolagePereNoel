using UI;
using UnityEngine;

namespace Gift
{
    public class Gift : MonoBehaviour, IInterctable
    {
        public GiftData GiftData { get; private set; }
        
        public void Interact(Bag bag)
        {
            bag.AddCoin(GiftData.CoinGain);
            CoinUI.Instance.Connect(bag);
            Destroy(gameObject);
            if (GiftSpawner.Instance.Root.GetComponentsInChildren<Transform>() == null)
            {
                Application.Quit();
            }
        }
        
        public void SetData(GiftData giftData)
        {
            GiftData = giftData;
        }
    }
}