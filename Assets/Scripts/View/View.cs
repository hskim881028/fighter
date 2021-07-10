using UnityEngine;

namespace Fighter.View {
    public abstract class View : MonoBehaviour, IView {
        private void Awake() {
            Initialize();
        }

        protected abstract void Initialize();

        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }

        public void UpdateActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}