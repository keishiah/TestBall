using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        // public List<IProgressSaver> ProgressSavers { get; } = new List<IProgressSaver>();
        // public List<IProgressReader> ProgressReaders { get; } = new List<IProgressReader>();
        private IInstantiator _instantiator;

        private GameObject _gameObjectsRoot;
        private GameObject _ballPrefab;
        private GameObject _racketPrefab;
        private GameObject _enemyRacketPrefab;
        private readonly IPlayerProgressService _playerProgressService;


        public GameFactory(IInstantiator instantiator, IPlayerProgressService playerProgressService)
        {
            _instantiator = instantiator;
            _playerProgressService = playerProgressService;
        }

        public void LoadResources()
        {
            _ballPrefab = Resources.Load(AssetPath.Ball) as GameObject;
            _racketPrefab = Resources.Load(AssetPath.Racket) as GameObject;
            _enemyRacketPrefab = Resources.Load(AssetPath.EnemyRacket) as GameObject;
        }

        public GameObject CreateRacket(Vector3 at)
        {
            var racket = _instantiator.InstantiatePrefab(_racketPrefab, _gameObjectsRoot.transform);
            racket.transform.position = at;
            return racket;
        }

        public GameObject CreateEnemyRacket(Vector3 at)
        {
            var racket = _instantiator.InstantiatePrefab(_enemyRacketPrefab, _gameObjectsRoot.transform);
            racket.transform.position = at;
            return racket;
        }

        public GameObject CreateBall(Vector3 at)
        {
            var ball = _instantiator.InstantiatePrefab(_ballPrefab, _gameObjectsRoot.transform);
            ball.GetComponent<MeshRenderer>().material.color = _playerProgressService.Progress.CustomStats.Color;
            return ball;
        }

        public void CreateGameobjectsRoot()
        {
            _gameObjectsRoot = new GameObject("GameobjectsRoot");
        }


        // private void RegisterProgressWatchers(GameObject gameObject)
        // {
        //     foreach (IProgressReader progressReader in gameObject.GetComponentsInChildren<IProgressReader>())
        //         Register(progressReader);
        // }
        //
        // private void Register(IProgressReader progressReader)
        // {
        //     if (progressReader is IProgressSaver progressWriter)
        //         ProgressSavers.Add(progressWriter);
        //
        //     ProgressReaders.Add(progressReader);
        // }
        //
        // private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        // {
        //     GameObject gameObject = _diContainer.InstantiatePrefab(Resources.Load(prefabPath));
        //     gameObject.transform.position = at;
        //     RegisterProgressWatchers(gameObject);
        //
        //     return gameObject;
        // }
        //
        // private GameObject InstantiateRegistered(string prefabPath)
        // {
        //     GameObject gameObject = _diContainer.InstantiatePrefab(Resources.Load(prefabPath));
        //     RegisterProgressWatchers(gameObject);
        //
        //     return gameObject;
        // }

        public void Cleanup()
        {
            // ProgressReaders.Clear();
            // ProgressSavers.Clear();
        }
    }
}