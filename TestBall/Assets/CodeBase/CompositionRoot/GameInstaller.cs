using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.Services;
using CodeBase.Services.InputService;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.StaticDataService;
using CodeBase.UI.Factories;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindLoadingCurtain();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();

            BindUIFactory();

            BindPlayerProgressService();

            BindSaveLoadService();

            BindInputService();

            BindHitCounter();

        }

        private void BindHitCounter()
        {
            Container.Bind<IHitCounter>().To<HitCounter>().AsSingle();
        }

        private void BindStaticDataService()
        {
            Container.Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromNewComponentOnNewGameObject();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindPlayerProgressService()
        {
            Container.Bind<IPlayerProgressService>()
                .To<PlayerProgressService>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container.Bind<IGameFactory>().To<GameFactory>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .BindInterfacesAndSelfTo<UIFactory>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }

        private void BindSceneLoader() =>
            Container.Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();

        private void BindLoadingCurtain()
        {
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(AssetPath.CurtainPath).AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadPlayerProgressState, LoadPlayerProgressState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}