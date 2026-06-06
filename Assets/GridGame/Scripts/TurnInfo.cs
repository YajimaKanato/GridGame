using System;
using UnityEngine;

namespace GridGame
{
    [CreateAssetMenu(fileName = "TurnInfo", menuName = "GridGame/TurnInfo")]
    public class TurnInfo : ScriptableObject
    {
        [SerializeField] TurnStats[] _turnStats;
        public TurnStats[] TurnStats => _turnStats;
    }

    [Serializable]
    public struct TurnStats
    {
        [SerializeField] TurnType _turnType;
        [SerializeField] Color _gridColor;
        [SerializeField] Color _energyColor;
        [SerializeField] Color _spawnEffectColor;

        public TurnType TurnType => _turnType;
        public Color GridColor => _gridColor;
        public Color EnergyColor => _energyColor;
        public Color SpawnEffectColor => _spawnEffectColor;
    }

    public enum TurnType
    {
        [InspectorName("自分のターン")] MyTurn = 0,
        [InspectorName("敵のターン")] EnemyTurn = 1
    }
}
