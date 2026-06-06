using UnityEngine;

namespace GridGame
{
    public class IngameManager : MonoBehaviour
    {
        [Header("Manager")]
        [SerializeField] TurnManager _turnManager;

        [SerializeField] PlayerInput _player;

        private void Awake()
        {
            foreach (GridBlock block in FindObjectsByType<GridBlock>(FindObjectsSortMode.None))
            {
                block.SetupMaterial();
            }
            _player?.Init(_turnManager);
        }
    }
}
