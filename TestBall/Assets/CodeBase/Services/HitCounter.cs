using System;
using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;

namespace CodeBase.Services
{
    public class HitCounter : IHitCounter
    {
        private IPlayerProgressService _progressService;


        private ISaveLoadService _saveLoadService;

        private int _currentHits = 0;

        public int _maxHits
        {
            get => _progressService.Progress.HitCounts.hitCounts;
        }

        public event Action<int> OnHitCountChanged;


        public HitCounter(IPlayerProgressService playerProgressService, ISaveLoadService saveLoadService)
        {
            _progressService = playerProgressService;
            _saveLoadService = saveLoadService;

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
                 _progressService.Progress.HitCounts.hitCounts = _currentHits;
                _saveLoadService.SaveProgress();
            }
        }

    }
}