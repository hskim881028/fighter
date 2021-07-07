using UnityEngine;

namespace Fighter.View {
    public class View : MonoBehaviour, IView {
        private void Awake() {
            Initialize();
        }

        protected virtual void Initialize() {
        }

        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }

        public void UpdateActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}