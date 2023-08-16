using CodeBase.Services.InputService;
using CodeBase.Services.StaticDataService;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        //Инициализируем сервисы
        private readonly IGameStateMachine gameStateMachine;
        private readonly IStaticDataService staticDataService;
        private readonly IInputService _inputService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IStaticDataService staticDataService, IInputService inputService)
        {
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
            _inputService = inputService;
        }

        public void Enter()
        {
            InitServices();
            gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        private async void InitServices()
        {
            staticDataService.Initialize();
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}