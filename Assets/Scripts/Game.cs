using Fighter.Action;
using Fighter.Manager;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        public static Game Instance;
        
        [SerializeField] private InputManager inputManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();

        public InputManager InputManager => inputManager;
        
        private void Awake() {
            Instance = this;
            GameManager.Initialize();
            UIManager.Initialize();
            CloneManager.Initialize(_actionHandler);
            CloneManager.ClonePlayer(Vector3.zero, Vector3.zero);
            // inputManager.Initialize(_actionHandler, CloneManager.GetPlayerModel());
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