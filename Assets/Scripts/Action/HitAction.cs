using Fighter.Manager;

namespace Fighter.Action {
    public class HitAction : IAction {
        private readonly Model.Model _attacker;
        private readonly Model.Model _defender;

        public HitAction(Model.Model attacker, Model.Model defender) {
            _attacker = attacker;
            _defender = defender;
        }

        public void Execute() {
            _defender.HP.Value -= _attacker.Damage.Value;
            if (_defender.HP.Value <= 0) {
                _defender.Active.Value = false;
                CloneManager.Destroy(_defender.ID);
            }
        }
    }
}