using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.UiElements
{
    public class ToMainMenuButton : MonoBehaviour
    {
        public Button toMainMenuButton;

        [Inject] private IGameStateMachine _gameStateMachine;

        private void Start()
        {
            toMainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        private void GoToMainMenu()
        {
            Time.timeScale = 1;
            _gameStateMachine.Enter<LoadLevelState, string>(AssetPath.StartGameScene);
        }
    }
}