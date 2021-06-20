using Fighter.Clone;
using Fighter.Action;
using Fighter.Manager;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private CloneSpawner cloneSpawner;
        private readonly ActionHandler _actionHandler = new ActionHandler();

        private void Awake() {
            ResourceManager.Initialize();
            CloneManager.Initialize(cloneSpawner, _actionHandler);
            var character = CloneManager.SpawnPlayer();
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