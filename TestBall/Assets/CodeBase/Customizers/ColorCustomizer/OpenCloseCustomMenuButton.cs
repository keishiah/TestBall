using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Customizers.ColorCustomizer
{
    public class OpenCloseCustomMenuButton : MonoBehaviour
    {
        public Button openCloseButton;
        public GameObject customMenu;
        private bool isOpen = false;

        private void Start()
        {
            openCloseButton.onClick.AddListener(OpenCloseMenu);
        }

        private void OpenCloseMenu()
        {
            isOpen = !isOpen;
            customMenu.SetActive(isOpen);
        }
    }
}