using TMPro;
using UnityEngine;

namespace SnakeView
{
    public class HudWindow : WindowBase
    {
        [SerializeField]
        private TextMeshProUGUI _score;

        public void SetScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}