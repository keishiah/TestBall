using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Static Data/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public GameObject UiPrefab;
        public LevelObjectsData LevelObjectsData;
    }

    [Serializable]
    public class LevelObjectsData
    {
        public List<GameObject> GameObjects;
        public List<Vector3> spawnPositions;
    }
}