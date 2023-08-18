using UnityEngine;

namespace CodeBase.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        GameObject CreateUiRoot();
        void CreateGameobjectsRoot();
        void CreateMainMenuUi();
    }
}