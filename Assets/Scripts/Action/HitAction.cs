using Fighter.Manager;
using Fighter.Effect.ValueObject;

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
            var vo = new DamageVO(_defender.Position.Value, _attacker.Damage.Value);
            EffectManager.CloneDamage(vo);
            if (_defender.HP.Value <= 0) {
                _defender.Active.Value = false;
                CloneManager.Destroy(_defender.ID);
            }
        }
    }
}