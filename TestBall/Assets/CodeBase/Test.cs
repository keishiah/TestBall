using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;
using Zenject;

namespace CodeBase
{
    public class Test : MonoBehaviour
    {
        private IGameFactory gameFactory;
        public GameObject cube;
        private IPlayerProgressService _progress;

        [Inject]
        void Construct(IPlayerProgressService progress)
        {
            _progress = progress;

        }
    }
}