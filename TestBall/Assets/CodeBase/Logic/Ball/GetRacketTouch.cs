using System;
using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class GetRacketTouch : MonoBehaviour
    {
        private int layerMask;
        private IHitCounter _hitCounter;
        private int previousRocketId;


        [Inject]
        void Construct(IHitCounter hitCounter)
        {
            _hitCounter = hitCounter;
        }

        private void Awake()
        {
            layerMask = 1 << LayerMask.NameToLayer("Racket");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (((1 << collision.gameObject.layer) & layerMask) != 0)
            {
                if (CheckCollisionRocketId(collision)) return;

                _hitCounter.GetHit();
            }
        }

        private bool CheckCollisionRocketId(Collision collision)
        {
            if (collision.gameObject.GetInstanceID() == previousRocketId) return true;
            previousRocketId = collision.gameObject.GetInstanceID();
            return false;
        }
    }
}