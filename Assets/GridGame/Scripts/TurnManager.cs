using UnityEngine;

namespace GridGame
{
    public class TurnManager : MonoBehaviour
    {
        [SerializeField] TurnInfo _turnInfo;
        TurnType _currentTurn;
        public TurnStats CurrentTurn => _turnInfo.TurnStats[(int)_currentTurn];

        [ContextMenu("ChangeTurn")]
        public void ChangeTurn()
        {
            if (_currentTurn == TurnType.MyTurn)
                _currentTurn = TurnType.EnemyTurn;
            else
                _currentTurn = TurnType.MyTurn;
            Debug.Log($"現在のターン : {_currentTurn}");
        }
    }
}
