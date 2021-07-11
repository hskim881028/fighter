using UnityEngine;

namespace Fighter.UI {
    public class UI {
        public UIType Type { get; }
        private readonly View.UIView _view;
        public bool IsActive { get; private set; }

        public UI(UIType type, View.UIView view, ValueObject.ValueObject vo) {
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