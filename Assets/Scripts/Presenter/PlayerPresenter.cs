using Fighter.Action;
using Fighter.Model;
using Fighter.View;
using UniRx;

namespace Fighter.Presenter {
    public class PlayerPresenter : Presenter<Character, PlayerView> {
        public PlayerPresenter(ActionHandler actionHandler, Model.Model model, View.View view)
            : base(actionHandler, model, view) {
        }

        public override void Initialize() {
            base.Initialize();
            _model.Look.Subscribe(x => {
                if (_view.isActiveAndEnabled) {
                    _view.UpdateLookAt(x);
                }
            });
        }

        public override void Update() {
            Movement();
        }

        private void Movement() {
            var direction = _model.Direction.Value;
            if (direction.sqrMagnitude > 0) {
                _actionHandler.Enqueue(new MoveAction(_model));
            }
        }
    }
}