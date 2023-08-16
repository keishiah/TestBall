using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public HitCounts HitCounts;

        public PlayerProgress()
        {
            HitCounts = new HitCounts();
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
}