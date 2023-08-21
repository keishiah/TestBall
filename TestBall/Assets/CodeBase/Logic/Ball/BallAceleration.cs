using System;
using UnityEngine;

namespace CodeBase.Logic
{
    public class BallAceleration : MonoBehaviour
    {
        private int layerMask;
        private Rigidbody ballRgidBody;


        private void Awake()
        {
            layerMask = 1 << LayerMask.NameToLayer("Racket");
            ballRgidBody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (((1 << collision.gameObject.layer) & layerMask) != 0)
            {
                AccelerateBall(collision);
            }
        }

        private void AccelerateBall(Collision collision)
        {
            float racketSpeed = collision.gameObject.GetComponent<GetRacketSpeed>().currentSpeed;

            var normalSpeed = ballRgidBody.velocity;
            ballRgidBody.velocity += normalSpeed * racketSpeed;
            GetComponent<BallMoving>().StartAceleration(normalSpeed, ballRgidBody.velocity);
        }
    }
}