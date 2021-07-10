using Fighter.Action;
using Fighter.Data;
using Fighter.Enum;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class PlayerPresenter : Presenter<Character, PlayerView> {
        private PlayerState _state = PlayerState.Idle;

        public PlayerPresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
        }

        public override void Initialize(int id, IData data, Vector3 position, Vector3 direction) {
            base.Initialize(id, data, position, direction);
            _model.Look.Subscribe(x => {
                if (_view.isActiveAndEnabled) {
                    _view.UpdateLookAt(x);
                }
            });

            Game.Instance.InputManager.Initialize(Lookat, Attack, Avoid);
        }

        protected override void UpdateState() {
            UpdateDisplacement();
        }

        protected override void ExecuteAction() {
            switch (_state) {
                case PlayerState.Move:
                    _actionHandler.Enqueue(new MoveAction(_model));
                    break;
            }
        }

        private void UpdateDisplacement() {
            var direction = _model.Direction.Value;
            _state = direction.sqrMagnitude > 0 ? PlayerState.Move : PlayerState.Idle;
        }

        private void Attack() {
            _state = PlayerState.Attack;
            _actionHandler.Enqueue(new AttackAction(_model));
        }

        private void Lookat(Vector3 direction) {
            _state = PlayerState.Lookat;
            _actionHandler.Enqueue(new LookAtAction(_model, direction));
        }

        private void Avoid() {
            _state = PlayerState.Avoid;
            _actionHandler.Enqueue(new AvoidAction(_model));
        }
    }
}