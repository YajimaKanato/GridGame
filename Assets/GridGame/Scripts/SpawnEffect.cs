using UnityEngine;
using UnityEngine.VFX;

namespace GridGame
{
    public class SpawnEffect : MonoBehaviour
    {
        [SerializeField] VisualEffect _effect;

        public void Spawn(Color color)
        {
            if (!_effect) return;
            _effect.SetVector4("BaseColor", color);
            _effect.Play();
        }
    }
}
