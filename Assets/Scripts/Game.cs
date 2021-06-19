using Fighter.Action;
using Fighter.Manager;
using Fighter.Presenter;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private ObjectManager ObjectManager;
        private readonly ActionHandler _actionHandler = new ActionHandler();
        private readonly PresenterHandler _presenterHandler = new PresenterHandler();

        private void Awake() {
            ResourceManager.Initialize();
            var (presenter, character) = ObjectManager.SpawnPlayer(_actionHandler);
            _presenterHandler.Add(presenter);
            inputManager.Initialize(_actionHandler, character);
        }

        private void Update() {
            _presenterHandler.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }
    }
}