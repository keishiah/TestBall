using CodeBase.Infrastructure.Factories;
using CodeBase.UI.Factories;
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
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            this.loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
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
            InitGame();
        }

        private void InitGame()
        {
            _gameFactory.CreateRacket(new Vector3(0, 0, -9));
            _gameFactory.CreateRacket(new Vector3(0, 0, 9));
            _gameFactory.CreateBall(new Vector3(0, 0, 0));
            _uiFactory.CreateUiRoot();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}