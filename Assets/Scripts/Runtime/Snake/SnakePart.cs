using UnityEngine;

namespace Snake
{
    public struct SnakePart
    {
        public GameObject Part;

        public SnakePart(GameObject part)
        {
            Part = part;
        }
    }
}