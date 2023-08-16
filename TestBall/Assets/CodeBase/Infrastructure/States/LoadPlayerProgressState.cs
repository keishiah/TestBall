using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadPlayerProgressState : IState
    {
        private readonly IGameStateMachine gameStateMachine;

        private readonly ISaveLoadService saveLoadService;

        private readonly IPlayerProgressService progressService;
        private readonly IGameFactory _gameFactory;

        public LoadPlayerProgressState(IGameStateMachine gameStateMachine, IPlayerProgressService progressService,
            ISaveLoadService saveLoadService, IGameFactory gameFactory)
        {
            this.gameStateMachine = gameStateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            var progress = LoadProgressOrInitNew();

            NotifyProgressReaderServices(progress);

            gameStateMachine.Enter<LoadLevelState, string>(AssetPath.StartGameScene);
        }

        private void NotifyProgressReaderServices(PlayerProgress progress)
        {
            foreach (var reader in _gameFactory.ProgressReaders)
                reader.LoadProgress(progress);
        }

        public void Exit()
        {
        }

        private PlayerProgress LoadProgressOrInitNew()
        {
            progressService.Progress =
                saveLoadService.LoadProgress()
                ?? NewProgress();
            return progressService.Progress;
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();

            // init start state of progress here

            return progress;
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadPlayerProgressState>
        {
        }
    }
}