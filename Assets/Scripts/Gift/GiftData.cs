using UnityEngine;

namespace Gift
{
    [CreateAssetMenu(fileName = "GiftData", menuName = "Data/GiftData")]
    public class GiftData : ScriptableObject
    {
        [field: SerializeField]
        public int CoinGain { get; private set; }
        
        [field: SerializeField]
        public Gift Prefab { get; private set; }
    }
}