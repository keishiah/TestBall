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
        private readonly GameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private string _sceneName;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IUIFactory uiFactory,
            GameFactory gameFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            sceneLoader.Load(sceneName, OnLoaded);
            _sceneName = sceneName;
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            if (_sceneName == "GamePlay")
                InitGame();
            if (_sceneName == "MainMenu")
                InitMainMenu();
        }

        private void InitMainMenu()
        {
            _uiFactory.CreateGameobjectsRoot();
            _uiFactory.CreateMainMenuUi();
        }

        private void InitGame()
        {
            _gameFactory.CreateGameobjectsRoot();
            _gameFactory.LoadResources();
            _gameFactory.CreateRacket(new Vector3(0, 0, -9));
            _gameFactory.CreateRacket(new Vector3(0, 0, 9));
            _gameFactory.CreateBall(new Vector3(0, 0, 0));
            _uiFactory.CreateGameobjectsRoot();
            _uiFactory.CreateUiRoot();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}