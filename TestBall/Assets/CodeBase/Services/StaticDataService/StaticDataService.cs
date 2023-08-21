using CodeBase.StaticData;
using JetBrains.Annotations;
using UnityEngine;

namespace CodeBase.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string ColorStaticDataPath = "StaticData/Colors/Color";


        [CanBeNull] public Color[] _colors { get; set; }

        public void Initialize()
        {
            _colors = Resources.Load<CustomColorStaticData>(ColorStaticDataPath).Colors;
        }

    }
}