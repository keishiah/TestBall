using System;
using CodeBase.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.UiElements
{
    public class HitCounterLabel : MonoBehaviour
    {
        public TextMeshProUGUI hitText;
        private IHitCounter _hitCounter;

        [Inject]
        void Construct(IHitCounter hitCounter)
        {
            _hitCounter = hitCounter;
        }

        private void Start()
        {
            SetHitCounts(_hitCounter._maxHits);
            _hitCounter.OnHitCountChanged += SetHitCounts;
        }

        private void SetHitCounts(int value)
        {
            hitText.text = value.ToString();
        }

        private void OnDestroy()
        {
            _hitCounter.OnHitCountChanged -= SetHitCounts;
        }
    }
}