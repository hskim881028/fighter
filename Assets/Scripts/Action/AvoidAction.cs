using Fighter.Model;

namespace Fighter.Action {
    public class AvoidAction : IAction {
        private readonly Character _model;
        
        public AvoidAction(Character model) {
            _model = model;
        }

        public void Execute() {
            _model.Position.Value += _model.Look.Value * _model.Avoid.Value;
        }
    }
}