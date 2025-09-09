using UnityEngine;

namespace SnakeView.Config
{
    [CreateAssetMenu(fileName = "SkinConfig", menuName = "Snake/Skin Config", order = 0)]
    public class GameSkinConfig : ScriptableObject
    {
        public readonly string BuildInSkinFallback = "SkinBuildIn";

        [field: SerializeField] public string SkinName { get; set; }
    }
}