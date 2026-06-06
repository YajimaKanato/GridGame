using UnityEngine;
using UnityEngine.InputSystem;

namespace GridGame
{
    public class PlayerInput : MonoBehaviour
    {
        TurnManager _turnManager;
        Vector2 _targetPos;
        RaycastHit _hit;
        bool _isHit;

        public void Init(TurnManager turnManager)
        {
            if (turnManager == null)
                throw new System.ArgumentNullException();
            _turnManager = turnManager;
        }

        private void Update()
        {
            // マウス座標取得
            Vector2 mousePos = _targetPos;

            // Ray生成
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            // Debug表示
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            // 当たり判定
            _isHit = Physics.Raycast(ray, out _hit, 100f);
        }

        /// <summary>
        /// PlayerInputから呼び出されるマウスの場所をとるメソッド
        /// </summary>
        /// <param name="input"></param>
        void OnTarget(InputValue input)
        {
            _targetPos = input.Get<Vector2>();
        }

        /// <summary>
        /// PlayerInputから呼び出されるスポーンメソッド
        /// </summary>
        void OnSpawn()
        {
            if (!_isHit || !_hit.collider.TryGetComponent<GridBlock>(out var grid)) return;
            grid.Spawn(_turnManager.CurrentTurn);
        }
    }
}
