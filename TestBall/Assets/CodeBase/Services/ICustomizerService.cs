using UnityEngine;

namespace CodeBase.Services
{
    public interface ICustomizerService
    {
        Color[] GetColors();
        void ChangeColor(Color color);
    }
}