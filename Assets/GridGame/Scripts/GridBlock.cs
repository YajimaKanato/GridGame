using UnityEngine;

namespace GridGame
{
    public class GridBlock : MonoBehaviour
    {
        [SerializeField] Renderer _render;
        [SerializeField] SpawnEffect _spawnEffect;
        [SerializeField] Color _baseColor;
        [SerializeField] Color _energyColor;
        [SerializeField] float _timeOffset;
        [SerializeField] float _stopTime;
        MaterialPropertyBlock _matBlock;
        float _delta;

        private void Awake()
        {
            _matBlock = new MaterialPropertyBlock();
            _spawnEffect?.gameObject.SetActive(false);
            SetupMaterial();
        }

        private void Update()
        {

            UpdateMaterial();
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            _spawnEffect?.gameObject?.SetActive(true);
        }

        void SetupMaterial()
        {
            _render.GetPropertyBlock(_matBlock);
            _matBlock?.SetColor("_BaseColor", _baseColor);
            _matBlock?.SetColor("_EnergyColor", _energyColor);
            _render.SetPropertyBlock(_matBlock);
        }

        void UpdateMaterial()
        {
            _render.GetPropertyBlock(_matBlock);
            _matBlock?.SetFloat("_CurretnTime", Time.time + _timeOffset);
            _render.SetPropertyBlock(_matBlock);
        }
    }
}
