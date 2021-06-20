using Fighter.Action;
using Fighter.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighter.Manager {
    public class InputManager : MonoBehaviour {
        private ActionHandler _actionHandler;
        private Character _character;

        public void Initialize(ActionHandler actionHandler, Character character) {
            _actionHandler = actionHandler;
            _character = character;
        }

        private void OnMovement(InputValue value) {
            var inputMovement = value.Get<Vector2>();
            var direction = new Vector3(inputMovement.x, inputMovement.y, 0);
            _actionHandler.Enqueue(new LookAtAction(_character, direction));
        }
    }
}