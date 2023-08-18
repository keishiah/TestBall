using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Customizers.ColorCustomizer
{
    public class ChangeColorButton : MonoBehaviour
    {
        public Button changeColorButton;
        private ColorCustomizer _customizer;

        private void Start()
        {
            changeColorButton.onClick.AddListener(ChangeColor);
            _customizer = GetComponentInParent<ColorCustomizer>();
        }

        private void ChangeColor()
        {
            var color = GetComponentInChildren<Image>().color;
            _customizer.SetColor(color);
        }
    }
}