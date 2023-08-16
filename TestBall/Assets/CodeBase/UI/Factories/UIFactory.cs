using CodeBase.Infrastructure.AssetManagment;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _diContainer;

        public UIFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreateUiRoot()
        {
            var label = _diContainer.InstantiatePrefab(Resources.Load(AssetPath.UiRoot));
            return label;
        }


        public void Cleanup()
        {
        }
    }
}