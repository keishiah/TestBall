using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Services.PlayerProgressService;
using CodeBase.UI.HUD;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _diContainer;
        public List<IProgressSaver> ProgressSavers { get; } = new List<IProgressSaver>();
        public List<IProgressReader> ProgressReaders { get; } = new List<IProgressReader>();


        public GameFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreateRacket(Vector3 at)
        {
            var racket = _diContainer.InstantiatePrefab(Resources.Load(AssetPath.Racket));
            racket.transform.position = at;
            return racket;
        }

        public GameObject CreateBall(Vector3 at)
        {
            var ball = _diContainer.InstantiatePrefab(Resources.Load(AssetPath.Ball));
            ball.transform.position = at;
            return ball;
        }


        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (IProgressReader progressReader in gameObject.GetComponentsInChildren<IProgressReader>())
                Register(progressReader);
        }

        private void Register(IProgressReader progressReader)
        {
            if (progressReader is IProgressSaver progressWriter)
                ProgressSavers.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _diContainer.InstantiatePrefab(Resources.Load(prefabPath));
            gameObject.transform.position = at;
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _diContainer.InstantiatePrefab(Resources.Load(prefabPath));
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressSavers.Clear();
        }
    }
}