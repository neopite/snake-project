using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Snake
{
    public class GameOverWindow : WindowBase
    {
        [SerializeField]
        private TextMeshProUGUI _score;
        
        [SerializeField]
        private Button _playAgainButton;
        
        public Button.ButtonClickedEvent PlayAgainButtonOnClick => _playAgainButton.onClick;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}