using Fighter.Action;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighter.Manager {
    public class InputManager : MonoBehaviour {
        private ActionHandler _actionHandler;
        private Model.CharacterModel _characterModel;

        public void Initialize(ActionHandler actionHandler, Model.CharacterModel characterModel) {
            _actionHandler = actionHandler;
            _characterModel = characterModel;
        }

        private void OnMovement(InputValue value) {
            var inputMovement = value.Get<Vector2>();
            var direction = new Vector3(inputMovement.x, inputMovement.y, 0);
            _actionHandler.Enqueue(new LookAtAction(_characterModel, direction));
        }
    }
}