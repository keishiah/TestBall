using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Customizers.ColorCustomizer
{
    public class ColorCustomizer : MonoBehaviour
    {
        [SerializeField] private GameObject ContentContainer;
        [SerializeField] private GameObject colorPrefab;
        private ICustomizerService _customizer;

        [Inject]
        void Construct(ICustomizerService customizer)
        {
            _customizer = customizer;
        }

        private void Start()
        {
            InitColors();
        }

        public void SetColor(Color color)
        {
            _customizer.ChangeColor(color);
        }

        private void InitColors()
        {
            foreach (Color color in _customizer.GetColors())
            {
                var colorInstance = Instantiate(colorPrefab, ContentContainer.transform);
                colorInstance.GetComponentInChildren<Image>().color = new Color(color.r, color.g, color.b);
            }
        }
    }
}