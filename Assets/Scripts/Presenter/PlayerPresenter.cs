using Fighter.Action;
using Fighter.Model;
using Fighter.View;
using UniRx;

namespace Fighter.Presenter {
    public class PlayerPresenter : IPresenter {
        private readonly CharacterModel _model;
        private readonly ActionHandler _actionHandler;

        public PlayerPresenter(CharacterModel model, PlayerView view, ActionHandler actionHandler) {
            _model = model;
            _model.Position.Subscribe(x => {
                if (view.isActiveAndEnabled) {
                    view.UpdatePosition(x);
                }
            });

            _model.Look.Subscribe(x => {
                if (view.isActiveAndEnabled) {
                    view.UpdateLookAt(x);
                }
            });

            _model.Active.Subscribe(x => {
                if (view.isActiveAndEnabled) {
                    view.UpdateActive(x);
                }
            });

            _actionHandler = actionHandler;
        }

        private void Movement() {
            var direction = _model.Direction.Value;
            if (direction.sqrMagnitude > 0) {
                _actionHandler.Enqueue(new MoveAction(_model));
            }
        }

        public void Update() {
            Movement();
        }
    }
}