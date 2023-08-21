using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.UiElements
{
    public class PauseButton : MonoBehaviour
    {
        public Button pauseButton;
        public GameObject pauseHood;

        private bool _gamePaused = false;

        private void Start()
        {
            pauseButton.onClick.AddListener(OnGamePaused);
        }

        private void OnGamePaused()
        {
            _gamePaused = !_gamePaused;
            Time.timeScale = _gamePaused ? 0f : 1f;
            pauseHood.SetActive(_gamePaused);
        }
    }
}