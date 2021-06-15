using Fighter.Controller;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Fighter.Presenter {
    public class PlayerPresenter {
        private readonly Player _model;

        public PlayerPresenter(InputController inputController, Player model, PlayerView view) {
            inputController.Movement.Subscribe(Movement);
            
            _model = model;
            _model.Position.Subscribe(view.UpdatePosition);
        }

        private void Movement(InputValue value) {
            var inputMovement = value.Get<Vector2>();
            var direction = new Vector3(inputMovement.x, inputMovement.y, 0);
            var position = _model.Position.Value + direction * Time.deltaTime;
            _model.Position.SetValueAndForceNotify(position);
        }
    }
}
