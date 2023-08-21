using UnityEngine;

namespace CodeBase.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();

        void CreateGameobjectsRoot();
        void CreateMainMenuUi();
    }
}