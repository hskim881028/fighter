using Fighter.Action;
using Fighter.Manager;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        public static Game Instance;

        [SerializeField] private InputManager inputManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();
        private readonly Stage _stage = new Stage();

        public InputManager InputManager => inputManager;

        private void Awake() {
            Instance = this;
            GameManager.Initialize();
            EffectManager.Initialize();
            CloneManager.Initialize(_actionHandler);
            _stage.Initialize();
        }

        private void Update() {
            _stage.Update();
            CloneManager.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}