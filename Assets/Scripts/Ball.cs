using UnityEngine;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Initialize(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}