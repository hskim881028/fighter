using Fighter.Action;
using Fighter.Model;
using Fighter.View;
using UniRx;

namespace Fighter.Presenter {
    public class PlayerPresenter : IPresenter {
        private readonly Player _model;
        private readonly ActionHandler _actionHandler;

        public PlayerPresenter(Player model, PlayerView view, ActionHandler actionHandler) {
            _model = model;
            _model.Position.Subscribe(view.UpdatePosition);
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