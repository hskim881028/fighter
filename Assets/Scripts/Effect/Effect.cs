using UnityEngine;

namespace Fighter.Effect {
    public class Effect {
        public EffectType Type { get; }
        private readonly View.EffectView _view;
        public bool IsActive { get; private set; }

        public Effect(EffectType type, View.EffectView view, ValueObject.ValueObject vo) {
            IsActive = true;
            Type = type;
            _view = view;
            _view.Initialize(vo, Destroy);
        }

        public void Respawn(ValueObject.ValueObject vo) {
            _view.gameObject.SetActive(true);
            _view.Initialize(vo, Destroy);
            IsActive = true;
        }

        private void Destroy() {
            IsActive = false;
            _view.gameObject.SetActive(false);
        }
    }
}