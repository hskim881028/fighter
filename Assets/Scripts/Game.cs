using Fighter.Action;
using Fighter.Manager;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private CloneManager cloneManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();

        private void Awake() {
            ResourceManager.Initialize();
            var character = cloneManager.SpawnPlayer(_actionHandler);
            inputManager.Initialize(_actionHandler, character);
        }

        private void Update() {
            cloneManager.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}