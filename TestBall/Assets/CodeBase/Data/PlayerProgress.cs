using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public HitCounts HitCounts;
        public CustomStats CustomStats;

        public PlayerProgress()
        {
            HitCounts = new HitCounts();
            CustomStats = new CustomStats();
        }
    }

    [Serializable]
    public class HitCounts
    {
        public int hitCounts = 0;

        public void SetHit(int maxHits)
        {
            hitCounts = maxHits;
        }
    }

    [Serializable]
    public class CustomStats
    {
        public Color Color;

        public CustomStats()
        {
            Color = new Color(0, 0, 0);
        }
    }
}