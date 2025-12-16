using UnityEngine;
using Random = UnityEngine.Random;

namespace Gift
{
    public class GiftSpawner : MonoBehaviour
    {
        [field : SerializeField]
        public Transform[] SpawnPoints { get; private set; }
        
        [field : SerializeField]
        public Transform Root { get; private set; }
        
        private GiftData[] giftDatas;

        private void Awake()
        {
            giftDatas = Resources.LoadAll<GiftData>("Datas/GiftDatas");
            SpawnPoints = Root.GetComponentsInChildren<Transform>();
            foreach (Transform child in Root)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                int randomNumber = Random.Range(0, giftDatas.Length);
                GiftData giftData = giftDatas[randomNumber];
                Gift instance = Instantiate(giftData.Prefab, Root);
                instance.SetData(giftData);
                instance.transform.position = SpawnPoints[i].position;
            }
        }

        private void Reset()
        {
            SpawnPoints = Root.GetComponentsInChildren<Transform>();
        }
    }
}