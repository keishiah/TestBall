using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class BallOut : MonoBehaviour
    {
        private IHitCounter _hitCounter;

        [Inject]
        void Construct(IHitCounter hitCounter)
        {
            _hitCounter = hitCounter;
        }


        private void Update()
        {
            if (transform.position.z is > 10 or < -10)
                OnBallOut();
        }

        private void OnBallOut()
        {
            RestartBallPosition();
            SaveHitProgress();
        }

        private void RestartBallPosition()
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(0, 0, 0);
            gameObject.GetComponent<BallMoving>().SetStartForce();
        }

        private void SaveHitProgress()
        {
            _hitCounter.SaveMaxHitCount();
            _hitCounter.ResetHits();
        }
    }
}