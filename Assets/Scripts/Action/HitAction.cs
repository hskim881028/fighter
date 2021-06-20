using Fighter.Manager;

namespace Fighter.Action {
    public class HitAction : IAction {
        private readonly Model.Model _model;

        public HitAction(Model.Model model) {
            _model = model;
        }

        public void Execute() {
            if (_model.HP.Value <= 0) {
                _model.Active.Value = false;
                CloneManager.Destroy(_model.ID);
            }
        }
    }
}