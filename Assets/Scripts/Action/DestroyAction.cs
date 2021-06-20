using Fighter.Manager;

namespace Fighter.Action {
    public class DestroyAction : IAction {
        private readonly Model.Model _model;

        public DestroyAction(Model.Model model) {
            _model = model;
        }

        public void Execute() {
            CloneManager.Destroy(_model.ID);
        }
    }
}