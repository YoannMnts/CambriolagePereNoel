using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gift
{
    public class GiftSpawner : MonoBehaviour
    {
        [field : SerializeField]
        public Vector3[] SpawnPoints { get; private set; }
        
        [field : SerializeField]
        public Transform Root { get; private set; }
        
        private GiftData[] giftDatas;

        private void Awake()
        {
            giftDatas = Resources.LoadAll<GiftData>("Datas/GiftDatas");
            if (giftDatas != null)
            {
                var gifts = Root.GetComponentsInChildren<Gift>();
                SpawnPoints = new Vector3[gifts.Length];
                for (int i = 0; i < gifts.Length; i++)
                {
                    //Debug.Log(gifts[i].gameObject.transform.position);
                    SpawnPoints[i] = gifts[i].gameObject.transform.position;
                }
                foreach (Transform child in Root)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < SpawnPoints.Length; i++)
                {
                    int randomNumber = Random.Range(0, giftDatas.Length);
                    GiftData giftData = giftDatas[randomNumber];
                    Gift instance = Instantiate(giftData.Prefab, SpawnPoints[i], Quaternion.identity, Root);
                    instance.SetData(giftData);
                } 
            }
        }
    }
}