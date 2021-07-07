using UnityEngine;

namespace Fighter.UI {
    public class UI {
        public UIType Type { get; }
        private readonly View.UIView _view;
        public bool IsActive { get; private set; }

        public UI(UIType type, View.UIView view, Vector3 position) {
            IsActive = true;
            Type = type;
            _view = view;
            _view.Initialize(Destroy, position);
        }

        public void Respawn(Vector3 position) {
            _view.gameObject.SetActive(true);
            _view.Initialize(Destroy, position);
            IsActive = true;
        }

        private void Destroy() {
            IsActive = false;
            _view.gameObject.SetActive(false);
        }
    }
}