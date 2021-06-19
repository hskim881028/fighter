using Fighter.Action;
using Fighter.Controller;
using Fighter.Manager;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;
using UnityEngine;

namespace Fighter {
    public class Game : MonoBehaviour {
        [SerializeField] private InputController inputController;
        private readonly ActionHandler _actionHandler = new ActionHandler();
        private readonly PresenterHandler _presenterHandler = new PresenterHandler();

        private void Awake() {
            ResourceManager.Initialize();
            var (presenter, character) = SpawnPlayer(_actionHandler);
            _presenterHandler.Add(presenter);
            inputController.Initialize(_actionHandler, character);
        }

        private void Update() {
            _presenterHandler.UpdateAll();
        }

        private void LateUpdate() {
            _actionHandler.ExecuteAll();
        }

        private (IPresenter, Character) SpawnPlayer(ActionHandler actionHandler) {
            var prefab = ResourceManager.GetPlayer(0);
            var clone = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            var view = clone.GetComponent<PlayerView>();
            var model = new Player(Vector3.zero, 5.0f);
            var presenter = new PlayerPresenter(model, view, actionHandler);
            return (presenter, model);
        }
    }
}