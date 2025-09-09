using UnityEngine;
using UnityEngine.UI;

namespace SnakeView
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] private Button _startButton;

        [SerializeField] private Button _exitButton;

        public Button.ButtonClickedEvent StartButtonOnClick => _startButton.onClick;
        public Button.ButtonClickedEvent ExitButtonOnClick => _exitButton.onClick;
    }
}