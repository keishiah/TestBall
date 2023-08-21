using System.Collections;
using CodeBase.Infrastructure.Factories;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Logic
{
    public class BallMoving : MonoBehaviour
    {
        private float startSpeed = 1f;
        private Rigidbody ballRigidBody;
        public Vector3 standartSpeed;

        private void Start()
        {
            SetStartForce();
            ballRigidBody = GetComponent<Rigidbody>();
        }

        public void SetStartForce()
        {
            Vector3 randomVector =
                new Vector3(Random.Range(-.9f, .9f), 0, startSpeed * Random.value > .5f ? -1 : 1);


            gameObject.GetComponent<Rigidbody>().AddForce(randomVector * 10f, ForceMode.VelocityChange);
        }

        public void StartAceleration(Vector3 normalSpeed, Vector3 acceleratedSpeed)
        {
            StartCoroutine(LerpBallSpeedAfterRacketCollision(normalSpeed, acceleratedSpeed));
        }

        private IEnumerator LerpBallSpeedAfterRacketCollision(Vector3 normalSpeed, Vector3 acceleratedSpeed)
        {
            while (acceleratedSpeed.magnitude - normalSpeed.magnitude >= .02f)

            {
                ballRigidBody.velocity =
                    ballRigidBody.velocity.normalized * Vector3.Lerp(acceleratedSpeed, normalSpeed, .05f).magnitude;
                acceleratedSpeed = ballRigidBody.velocity;
                yield return null;
            }
        }
    }
}