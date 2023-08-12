using CodeBase.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly ISceneLoader sceneLoader;
        private readonly ILoadingCurtain loadingCurtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain,IGameFactory gameFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            loadingCurtain.Show();
            sceneLoader.Load(sceneName, OnLoaded);
            
            _gameFactory.Cleanup();

        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            loadingCurtain.Hide();
            _gameFactory.CreateTestMono();

        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}