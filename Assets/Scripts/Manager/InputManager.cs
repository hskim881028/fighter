using Fighter.Action;
using Fighter.Model;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighter.Manager {
    public class InputManager : MonoBehaviour {
        private System.Action<Vector3> _lookat;
        private System.Action _attack;
        private System.Action _avoid;

        public void Initialize(System.Action<Vector3> lookat, System.Action attack, System.Action avoid) {
            _attack = attack;
            _lookat = lookat;
            _avoid = avoid;
        }

        private void OnLookat(InputValue value) {
            var inputMovement = value.Get<Vector2>();
            var direction = new Vector3(inputMovement.x, inputMovement.y, 0);
            _lookat?.Invoke(direction);
        }

        private void OnAttack() {
            _attack?.Invoke();
        }

        private void OnAvoid() {
            _avoid?.Invoke();
        }
    }
}