using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services.PlayerProgressService;
using UnityEngine;

namespace CodeBase.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        
        private readonly IPlayerProgressService _playerProgressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPlayerProgressService playerProgressService,IGameFactory gameFactory)
        {
            this._playerProgressService = playerProgressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (var saver in _gameFactory.ProgressSavers) 
                saver.UpdateProgress(_playerProgressService.Progress);
            
            PlayerPrefs.SetString(ProgressKey, _playerProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
        }
    }
}