using System.Collections;
using UnityEngine;

namespace GridGame
{
    public class SpawnEffect : MonoBehaviour
    {
        [SerializeField] Renderer _render;
        [SerializeField] float _effectTime = 0.5f;

        MaterialPropertyBlock _matBlock;
        float _delta = 0;

        private void Awake()
        {
            _matBlock = new MaterialPropertyBlock();
        }

        private void Update()
        {
            _delta += Time.deltaTime;

            _render.GetPropertyBlock(_matBlock);
            _matBlock.SetFloat("_CurrentTime", _delta * (Mathf.PI / _effectTime));
            _render.SetPropertyBlock(_matBlock);

            if (_delta >= _effectTime)
            {
                _delta = 0;
                gameObject?.SetActive(false);
            }
        }
    }
}
