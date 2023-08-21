using CodeBase.Data;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.SaveLoadService;
using CodeBase.Services.StaticDataService;
using UnityEngine;
using Zenject;
using Color = UnityEngine.Color;

namespace CodeBase.Services
{
    public class CustomizerService : ICustomizerService
    {
        private IStaticDataService _staticDataService;
        private IPlayerProgressService _playerProgressService;
        private ISaveLoadService _saveLoadService;

        private Color currentColor;

        [Inject]
        void Construct(IStaticDataService staticDataService, IPlayerProgressService playerProgressService,
            ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _playerProgressService = playerProgressService;
            _saveLoadService = saveLoadService;
        }

        public Color[] GetColors()
        {
            return _staticDataService._colors;
        }

        public void ChangeColor(Color color)
        {
            _playerProgressService.Progress.CustomStats.Color = color;
            _saveLoadService.SaveProgress();
        }
    }
}