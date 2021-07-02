using Fighter.Manager;

namespace Fighter.Action {
    public class AttackAction : IAction {
        private readonly Model.Model _model;

        public AttackAction(Model.Model model) {
            _model = model;
        }

        public void Execute() {
            CloneManager.CloneProjectile(_model.Position.Value, _model.Look.Value, 5.0f, 2);
        }
    }
}