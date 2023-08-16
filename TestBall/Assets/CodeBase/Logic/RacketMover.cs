using System;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic
{
    public class RacketMover : MonoBehaviour
    {
        private IInputService _inputService;


        [Inject]
        void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            Vector3 movement = new Vector3(_inputService.Axis, 0.0f, 0.0f) * 10f * Time.deltaTime;
            Vector3 newPosition = transform.position + movement;

            newPosition.x = Mathf.Clamp(newPosition.x, -3, 3);


            transform.position = newPosition;
        }
    }
}