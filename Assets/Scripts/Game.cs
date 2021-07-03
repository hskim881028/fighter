using Fighter.Action;
using Fighter.Manager;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputManager inputManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();

        private void Awake() {
            GameManager.Initialize();
            CloneManager.Initialize(_actionHandler);
            var player = CloneManager.ClonePlayer(Vector3.zero, Vector3.zero);
            inputManager.Initialize(_actionHandler, player);
            for (int i = 0; i < 5; i++) {
                CloneManager.CloneEnemy(new Vector3(i + 1, 0, 0), Vector3.zero);
            }
        }

        private void Update() {
            CloneManager.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}