using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] private Button _startButton;

        [SerializeField] private Button _exitButton;

        public Button.ButtonClickedEvent StartButtonOnClick => _startButton.onClick;
        public Button.ButtonClickedEvent ExitButtonOnClick => _startButton.onClick;
    }
}