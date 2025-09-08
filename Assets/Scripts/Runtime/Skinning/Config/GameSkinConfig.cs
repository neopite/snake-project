using UnityEngine;

namespace Snake.Skinning
{
    [CreateAssetMenu(fileName = "SkinConfig", menuName = "Snake/Skin Config", order = 0)]
    public class GameSkinConfig : ScriptableObject
    {
        [field:SerializeField]
        public GameSkinType Type { get; set; }
    }
}