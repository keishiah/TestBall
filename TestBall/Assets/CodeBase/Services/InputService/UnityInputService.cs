using UnityEngine;

namespace CodeBase.Services.InputService
{
    class UnityInputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        
        public float Axis => Input.GetAxis(Horizontal);
    }
}