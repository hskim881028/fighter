using Fighter.Manager;

namespace Fighter.Action {
    public class HitAction : IAction {
        private readonly Model.Model _attacker;
        private readonly Model.Model _defender;

        public HitAction((Model.Model, Model.Model) models) {
            var (attacker, defender) = models;
            _attacker = attacker;
            _defender = defender;
        }

        public void Execute() {
            _defender.HP.Value -= _attacker.Damage.Value;
            UIManager.CloneDamage(_defender.Position.Value);
            if (_defender.HP.Value <= 0) {
                _defender.Active.Value = false;
                CloneManager.Destroy(_defender.ID);
            }
        }
    }
}