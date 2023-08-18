using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Color", menuName = "Static Data/Color", order = 0)]
    public class CustomColorStaticData : ScriptableObject
    {
        public Color[] Colors;
    }
}