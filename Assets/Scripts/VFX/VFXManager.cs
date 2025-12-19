using System;
using Gift;
using TMPro;
using UI;
using UnityEngine;

namespace VFX
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField] private Bag bag;
        [SerializeField] private CoinUI coinUI;
        
        [field : SerializeField]
        public ParticleSystem Rocket { get; private set; }
        
        [field : SerializeField]
        public ParticleSystem Confetti { get; private set; }

        private void OnEnable()
        {
            bag.OnBagTriggered += PlayConfetti;
            coinUI.OnNewMaxScore += PlayRocket;
        }

        private void OnDisable()
        {
            bag.OnBagTriggered -= PlayConfetti;
            coinUI.OnNewMaxScore -= PlayRocket;
        }

        public void PlayConfetti()
        {
            Confetti.Play();
        }

        public void PlayRocket()
        {
            Rocket.Play();
        }
    }
}