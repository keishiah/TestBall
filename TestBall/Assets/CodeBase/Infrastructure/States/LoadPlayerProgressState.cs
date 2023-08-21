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

        public LoadPlayerProgressState(IGameStateMachine gameStateMachine, IPlayerProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            this.gameStateMachine = gameStateMachine;
            this.saveLoadService = saveLoadService;
            this.progressService = progressService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            gameStateMachine.Enter<LoadLevelState, string>(AssetPath.StartGameScene);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
        {
            progressService.Progress =
                saveLoadService.LoadProgress()
                ?? NewProgress();
            

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