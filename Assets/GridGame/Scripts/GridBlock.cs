using UnityEngine;

namespace GridGame
{
    public class GridBlock : MonoBehaviour
    {
        [SerializeField] Material _material;
        [SerializeField] Color _baseColor;
        [SerializeField] Color _energyColor;

        private void OnEnable()
        {
            _material?.SetColor("_BaseColor", _baseColor);
            _material?.SetColor("_EnergyColor", _energyColor);
        }

        private void Update()
        {
            _material?.SetFloat("_CurretnTime", Time.time);
        }

        private void OnDisable()
        {
            _material?.SetColor("_BaseColor", Color.white);
            _material?.SetColor("_EnergyColor", Color.white);
            _material?.SetFloat("_CurretnTime", 0);
        }
    }
}
