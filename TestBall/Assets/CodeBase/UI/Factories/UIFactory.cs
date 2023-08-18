using CodeBase.Infrastructure.AssetManagment;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _diContainer;
        private GameObject _gameObjectsRoot;

        public UIFactory(IInstantiator diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreateUiRoot()
        {
            var label = _diContainer.InstantiatePrefab(Resources.Load(AssetPath.UiRoot), _gameObjectsRoot.transform);
            return label;
        }

        public void CreateGameobjectsRoot()
        {
            _gameObjectsRoot = new GameObject("UiRoot");
        }

        public void CreateMainMenuUi()
        {
            _diContainer.InstantiatePrefab(Resources.Load(AssetPath.MaiMenuUiRoot), _gameObjectsRoot.transform);
        }

        public void Cleanup()
        {
        }
    }
}