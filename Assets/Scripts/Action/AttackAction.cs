using Fighter.Enum;
using Fighter.Manager;
using Fighter.Model;
using Fighter.Presenter;
using Fighter.View;

namespace Fighter.Action {
    public class AttackAction : IAction {
        private readonly Model.Model _model;

        public AttackAction(Model.Model model) {
            _model = model;
        }

        public void Execute() {
            CloneManager.Clone<Projectile, ProjectileView, ProjectilePresenter>(
                CloneType.Projectile, _model.Position.Value, _model.Look.Value);
        }
    }
}