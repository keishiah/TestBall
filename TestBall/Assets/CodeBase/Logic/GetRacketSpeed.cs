using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class GetRacketSpeed : MonoBehaviour
    {
        private Vector3 prevPos;
        public float currentSpeed;

        void Start()
        {
            StartCoroutine(CalcVelocity());
        }

        IEnumerator CalcVelocity()
        {
            while (Application.isPlaying)
            {
                // Position at frame start
                prevPos = transform.position;
                // Wait till it the end of the frame
                yield return new WaitForEndOfFrame();
                // Calculate velocity: Velocity = DeltaPosition / DeltaTime
                currentSpeed = ((prevPos - transform.position) / Time.deltaTime).magnitude;
            }
        }
    }
}