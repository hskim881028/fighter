using UnityEngine;

namespace Fighter.Action {
    public class MoveAction : IAction {
        private readonly Model.Model _model;

        public MoveAction(Model.Model model) {
            _model = model;
        }

        public void Execute() {
            var speed = _model.Speed.Value;
            var direction = _model.Direction.Value;
            var position = _model.Position.Value;
            _model.Position.Value = position + direction.normalized * (speed * Time.deltaTime);
        }
    }
}