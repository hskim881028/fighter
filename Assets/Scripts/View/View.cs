using UnityEngine;

namespace Fighter.View {
    public abstract class View : MonoBehaviour, IView {
        protected abstract void OnAwake();
        
        private void Awake() {
            OnAwake();
        }

        public void UpdatePosition(Vector3 position) {
            transform.position = position;
        }

        public void UpdateActive(bool value) {
            gameObject.SetActive(value);
        }
    }
}