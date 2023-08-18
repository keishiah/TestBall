using CodeBase.Infrastructure.States;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.UiElements
{
    public class RestartButton : MonoBehaviour
    {
        public Button restartButton;
        private IGameStateMachine _gameStateMachine;
        private IHitCounter _hitCounter;

        [Inject]
        void Construct(IGameStateMachine gameStateMachine, IHitCounter hitCounter)
        {
            _gameStateMachine = gameStateMachine;
            _hitCounter = hitCounter;
        }

        private void Start()
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            _hitCounter.ResetHits();
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}