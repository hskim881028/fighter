using Fighter.Action;
using Fighter.Data;
using Fighter.Model;
using Fighter.View;
using UniRx;
using UnityEngine;

namespace Fighter.Presenter {
    public class PlayerPresenter : Presenter<Character, PlayerView> {
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
            
            //todo UI 만들고 처리
            // _model.HP.Subscribe(x => {
            //
            // });
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