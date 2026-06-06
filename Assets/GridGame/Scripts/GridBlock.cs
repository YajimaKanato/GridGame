using UnityEngine;

namespace GridGame
{
    public class GridBlock : MonoBehaviour
    {
        [SerializeField] TurnInfo _turnInfo;
        [SerializeField] Renderer _render;
        [SerializeField] SpawnEffect _spawn;
        [SerializeField] float _timeOffset;
        [SerializeField] float _stopTime;
        MaterialPropertyBlock _matBlock;

        private void Update()
        {
            UpdateMaterial();
        }

        [ContextMenu("Spawn")]
        public void Spawn(TurnStats turn)
        {
            // スポーンエフェクトに色を適用
            _spawn?.Spawn(turn.SpawnEffectColor);

            // ブロックの色を変更
            _render.GetPropertyBlock(_matBlock);
            _matBlock?.SetColor("_BaseColor", turn.GridColor);
            _matBlock?.SetColor("_EnergyColor", turn.EnergyColor);
            _render.SetPropertyBlock(_matBlock);
        }

        [ContextMenu("Dead")]
        public void Dead()
        {
            // ブロックの色を変更
            _render.GetPropertyBlock(_matBlock);
            _matBlock?.SetColor("_BaseColor", Color.white);
            _matBlock?.SetColor("_EnergyColor", Color.white);
            _render.SetPropertyBlock(_matBlock);
        }

        public void SetupMaterial()
        {
            _matBlock = new MaterialPropertyBlock();
            _render.GetPropertyBlock(_matBlock);
            _matBlock?.SetFloat("_WaitTime", _stopTime);
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
