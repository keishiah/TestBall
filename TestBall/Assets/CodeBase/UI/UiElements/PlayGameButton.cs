using System;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.UiElements
{
    public class PlayGameButton : MonoBehaviour
    {
        public Button playButton;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        private void Start()
        {
            playButton.onClick.AddListener(PlayGame);
        }

        private void PlayGame()
        {
            _gameStateMachine.Enter<LoadLevelState,string>("GamePlay");
        }
    }
}