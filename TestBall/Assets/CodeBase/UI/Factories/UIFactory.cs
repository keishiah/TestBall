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


        public void CreateGameobjectsRoot()
        {
            _gameObjectsRoot = new GameObject("UiRoot");
        }

        public void CreateMainMenuUi()
        {
        }

        public void Cleanup()
        {
        }
    }
}