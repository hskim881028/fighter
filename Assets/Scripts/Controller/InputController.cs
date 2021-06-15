using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighter.Controller {
    public class InputController : MonoBehaviour {
        public readonly Subject<InputValue> Movement = new Subject<InputValue>();

        private void OnMovement(InputValue value) {
            Movement.OnNext(value);
        }
    }
}