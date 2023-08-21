using System;

namespace CodeBase.Services
{
    public interface IHitCounter
    {
        void GetHit();
        void SaveMaxHitCount();
        void ResetHits();
        int _maxHits { get; }
        event Action<int> OnHitCountChanged;
    }
}