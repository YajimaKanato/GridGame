using UnityEngine;
using UnityEngine.InputSystem;

namespace GridGame
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] InputActionAsset _actionAsset;
        InputActionMap _testMap;
        InputAction _targetAct;
        InputAction _spawnAct;
        RaycastHit _hit;
        bool _isHit;

        private void Awake()
        {
            _testMap = _actionAsset.FindActionMap("Test");
            _targetAct = _testMap.FindAction("Target");
            _spawnAct = _testMap.FindAction("Spawn");

            _testMap.Enable();
        }

        private void Update()
        {
            // マウス座標取得
            Vector2 mousePos = _targetAct.ReadValue<Vector2>();

            // Ray生成
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            // Debug表示
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

            // 当たり判定
            _isHit = Physics.Raycast(ray, out _hit, 100f);
        }

        private void OnEnable()
        {
            RegisterAction();
        }

        private void OnDisable()
        {
            UnregisterAction();
        }

        void RegisterAction()
        {
            _spawnAct.started += Spawn;
        }

        void UnregisterAction()
        {
            _spawnAct.started -= Spawn;
        }

        void Spawn(InputAction.CallbackContext ctx)
        {
            if (!_isHit || !_hit.collider.TryGetComponent<GridBlock>(out var grid)) return;
            grid.Spawn();
        }
    }
}
