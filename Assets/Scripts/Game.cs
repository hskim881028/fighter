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
            var character = CloneManager.ClonePlayer(Vector3.zero, Vector3.zero);
            inputManager.Initialize(_actionHandler, character);
        }

        private void Update() {
            CloneManager.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}