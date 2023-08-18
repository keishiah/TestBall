using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;

namespace CodeBase.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPlayerProgressService _playerProgressService;

        public SaveLoadService(IPlayerProgressService playerProgressService)
        {
            this._playerProgressService = playerProgressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, _playerProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}