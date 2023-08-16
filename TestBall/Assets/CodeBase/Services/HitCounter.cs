using System;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using UnityEngine;

namespace CodeBase.Services
{
    public interface IHitCounter
    {
        void GetHit();
        void SaveMaxHitCount();
        void ResetHits();
        int _maxHits { get; set; }
        event Action<int> OnHitCountChanged;
    }

    public class HitCounter : IHitCounter, IProgressSaver
    {
        private int _currentHits = 0;

        public int _maxHits
        {
            get => _progressService.Progress.HitCounts.hitCounts;
            set => _progressService.Progress.HitCounts.hitCounts = value;
        }

        private IPlayerProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public event Action<int> OnHitCountChanged;


        public HitCounter(IPlayerProgressService playerProgressService, ISaveLoadService saveLoadService)
        {
            _progressService = playerProgressService;
            _saveLoadService = saveLoadService;

            LoadProgress(_progressService.Progress);
        }


        public void GetHit()
        {
            _currentHits++;
            SaveMaxHitCount();
            OnHitCountChanged?.Invoke(_maxHits);
        }

        public void ResetHits()
        {
            _currentHits = 0;
        }

        public void SaveMaxHitCount()
        {
            if (_currentHits > _maxHits)
            {
                UpdateProgress(_progressService.Progress);
                _saveLoadService.SaveProgress();
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HitCounts.hitCounts = _currentHits;
        }

        public void LoadProgress(PlayerProgress progress)
        {
        }
    }
}